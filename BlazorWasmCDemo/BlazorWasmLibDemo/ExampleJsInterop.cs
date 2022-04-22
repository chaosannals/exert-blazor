using Microsoft.JSInterop;
using System.Reflection;

namespace BlazorWasmLibDemo;

public class ExampleJsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    private static AssemblyName assemblyName;
    public static AssemblyName AssemblyName { get => assemblyName; }

    static ExampleJsInterop()
    {
        assemblyName = Assembly.GetAssembly(typeof(ExampleJsInterop))!.GetName();
    }

    public ExampleJsInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", $"./_content/{AssemblyName.Name}/exampleJsInterop.js").AsTask());
    }

    public async ValueTask<string> Prompt(string message)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<string>("showPrompt", message);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
