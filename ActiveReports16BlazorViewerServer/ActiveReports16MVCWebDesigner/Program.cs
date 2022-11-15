using GrapeCity.ActiveReports.Aspnetcore.Designer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDesigner();

DirectoryInfo ResourcesRootDirectory = new DirectoryInfo(".\\resources\\");

var app = builder.Build();
app.UseDesigner(config => config.UseFileStore(ResourcesRootDirectory));
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
