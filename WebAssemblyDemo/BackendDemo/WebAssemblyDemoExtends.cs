using Microsoft.AspNetCore.Rewrite;
using System.Diagnostics.Tracing;

namespace BackendDemo;

using Microsoft.AspNetCore.Builder;

public static class WebAssemblyDemoExtends
{
    public static WebApplication UseWebAssemblyBlazor(this WebApplication app)
    {
        /*
        app.UseBlazorFrameworkFiles(new PathString("/demo"));
        app.UseStaticFiles("/demo");
        app.MapFallbackToFile("/demo/{*path:nonfile}", "demo/index.html");
        */
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();
        app.MapFallbackToFile("/{*path:nonfile}", "index.html");
        return app;
    }

    public static WebApplication UseWebAssemblyDevServerProxy(this WebApplication app)
    {
        app.UseDeveloperExceptionPage();
        app.UseWebAssemblyDebugging();
        /*
        app.UseSpa(spa =>
        {
            spa.UseProxyToSpaDevelopmentServer("https://localhost:17025/demo");
        });
        */
        //var opt = new RewriteOptions();
        // opt.AddRewrite();
        // app.UseRewriter(opt);
        app.MapWhen(context =>
        {
            /*
            // 
            PathString prefixs = new PathString("/demo");
            return context.Request.Path.StartsWithSegments(prefixs);
            */

            // 只有 API 下的不转发，其他的都转发。
            PathString prefixs = new PathString("/api");
            return !context.Request.Path.StartsWithSegments(prefixs);
        }, builder =>
        {
            builder.RunProxy(new ProxyOptions
            {
                Scheme = "https",
                Host = "localhost",
                Port = "17025",
            });
        });
        return app;
    }
}
