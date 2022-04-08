using BackendDemo;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddMvc();

var app = builder.Build();


// 调试模式
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDevServerProxy();
}
else
{
    app.UseWebAssemblyBlazor();
}

Func<Task<IResult>> api = async () =>
{
    return Results.Json(new
    {
        Code = 0,
    });
};

app.MapPost("/api", api);

app.UseAuthentication();
app.UseAuthorization();

app.Run();
