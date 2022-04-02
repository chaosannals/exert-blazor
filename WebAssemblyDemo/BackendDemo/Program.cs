﻿using BackendDemo;

var builder = WebApplication.CreateBuilder(args);
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

app.Run();
