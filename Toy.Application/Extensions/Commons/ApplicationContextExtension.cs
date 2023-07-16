using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Toy.Application.Services.Contexts;

namespace Toy.Application.Extensions.Commons;

public static class ApplicationContextExtension
{
    public static void AddApplicationContext<T>(
        this IServiceCollection service,
        string connectionStringName) where T : DbContext
    {
        // Sql Servers
        service.AddScoped<T>(serviceProvider =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString(connectionStringName)!;
            var contextFactory = serviceProvider.GetRequiredService<DevelopContextFactory>();
            return contextFactory.Create<T>(connectionString);
        });
    }
}
