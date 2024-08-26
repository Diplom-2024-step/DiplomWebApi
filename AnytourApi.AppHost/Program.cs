var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AnytourApi_WebApi>("anytourapi-webapi");

builder.Build().Run();
