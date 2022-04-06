using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using WebAssemblyDemo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(s => new CustomAuthenticationStateProvider());
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// 增加 BootstrapBlazor 组件
builder.Services.AddBootstrapBlazor(op =>
{
    // 设置组件默认使用中文
    op.DefaultCultureInfo = "zh";
});

await builder.Build().RunAsync();
