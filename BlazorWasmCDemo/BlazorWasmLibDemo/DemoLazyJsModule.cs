using Microsoft.JSInterop;
using System.Reflection;

namespace BlazorWasmLibDemo;

public class DemoLazyJsModule<T> : IAsyncDisposable
{
    public AssemblyName AssemblyName { get; init; }
    public Lazy<Task<IJSObjectReference>> ModuleTask { get; init; }

    public DemoLazyJsModule(IJSRuntime jsRuntime)
    {
        var t = typeof(T);
        AssemblyName = t.Assembly.GetName();
        ModuleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", $"./_content/{AssemblyName.Name}/{t.Name}.razor.js").AsTask());
    }

    public async ValueTask<R> CallAsync<R>(string name,params object?[]? args)
    {
        var m = await ModuleTask.Value;
        return await m.InvokeAsync<R>(name, args);
    }

    public async Task CallVoidAsync(string name, params object?[]? args)
    {
        var m = await ModuleTask.Value;
        await m.InvokeVoidAsync(name, args);
    }

    public async ValueTask DisposeAsync()
    {
        if (ModuleTask.IsValueCreated)
        {
            var module = await ModuleTask.Value;
            await module.DisposeAsync();
        }
    }
}
