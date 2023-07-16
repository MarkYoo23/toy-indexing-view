using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Toy.Application.Extensions.Commons;
using Toy.Application.Services.Contexts;
using Toy.Application.Services.Initialize;
using Toy.Application.Services.Notices;
using Toy.Domain.Channels;
using Toy.Domain.Notices;
using Toy.Infrastructure.Contexts;
using Toy.Infrastructure.Repositories;

namespace Toy.Application.Extensions;

public static class ApplicationExtensions
{
    public static void AddApplicationContexts(this IServiceCollection services)
    {
        services.AddSingleton<DevelopContextFactory>();
        services.AddApplicationContext<SolutionContext>("SqlServer");
    }
    
    public static void AddApplicationRepositories(this IServiceCollection services)
    {
        services.AddScoped<INoticeRepository, NoticeRepository>();
        services.AddScoped<IChannelRepository, ChannelRepository>();
    }
    
    public static void AddApplicationQueryService(this IServiceCollection services)
    {
        services.AddScoped<NoticeQueryService>();
    }
    
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<DbInitializeService>();
        services.AddScoped<DataInitializeService>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}