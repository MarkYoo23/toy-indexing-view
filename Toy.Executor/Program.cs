using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Toy.Application.Extensions;
using Toy.Application.Services.Initialize;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
{
    // https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration
    configurationBuilder.Sources.Clear();
    
    var env = hostingContext.HostingEnvironment;
    
    configurationBuilder
        .AddJsonFile("appsettings.json", true, false)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, false)
        .AddEnvironmentVariables();
});
builder.ConfigureServices(services =>
{
    services.AddApplicationContexts();
    services.AddApplicationServices();
});

var host = builder.Build();

using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

var dbInitializeService = serviceProvider.GetRequiredService<DbInitializeService>();
await dbInitializeService.ExecuteAsync();

var dataInitializeService = serviceProvider.GetRequiredService<DataInitializeService>();
dataInitializeService.Execute();

await host.StartAsync();
