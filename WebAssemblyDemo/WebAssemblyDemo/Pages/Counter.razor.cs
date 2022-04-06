namespace WebAssemblyDemo.Pages;

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using BootstrapBlazor.Components;
// using BootstrapBlazor.Shared.Common;

public partial class Counter
{
    // [NotNull]
    // private Message? Message { get; set; }

    [Inject]
    [NotNull]
    public MessageService? MessageService { get; set; }

    private async Task PopMessage()
    {
        await MessageService.Show(new MessageOption()
        {
            Content = "这是一条提示消息"
        });
    }
}
