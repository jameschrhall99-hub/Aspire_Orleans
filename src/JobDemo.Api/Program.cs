var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapDefaultEndpoints();

app.MapGet("/info", () =>
{
    app.Logger.LogInformation(
        "Information endpoint requested for {ServiceName} in {EnvironmentName}",
        "JobDemo.Api",
        app.Environment.EnvironmentName);

    return TypedResults.Ok(new
    {
        service = "JobDemo.Api",
        milestone = 1,
        environment = app.Environment.EnvironmentName,
        timestampUtc = DateTimeOffset.UtcNow
    });
})
.WithName("GetInfo")
.WithSummary("Returns basic information about the running API.");

app.Run();