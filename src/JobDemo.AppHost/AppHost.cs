var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.JobDemo_Api>("api", launchProfileName: "http")
    .WithHttpHealthCheck("/health");

builder.Build().Run();