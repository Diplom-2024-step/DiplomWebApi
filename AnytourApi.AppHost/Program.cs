using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var webapi = builder.AddProject<Projects.AnytourApi_WebApi>("anytourapi-webapi");

//builder.AddNpmApp("diplom-website", "../diplom-website", "dev")
//    .WithEnvironment("NODE_ENV", "development")
//    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
//    .WithReference(webapi)
//    .WithHttpEndpoint(env: "3000", name: "website", port: 3000, isProxied: false)
//    .WithEnvironment("NEXT_PUBLIC_BASE_URL", webapi.GetEndpoint("http") )
//    .WithExternalHttpEndpoints();

builder.Build().Run();
