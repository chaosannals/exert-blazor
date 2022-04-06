using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using BootstrapBlazor.Components;

namespace BootstrapBlazorDemo.Shared.Pages;

public partial class Counter
{
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
