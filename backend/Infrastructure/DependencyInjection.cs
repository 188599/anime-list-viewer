using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistence(configuration)
            .AddScoped<IAniListService, AniListService>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<AnimeListViewerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AnimeListViewer")))
            .AddScoped<IAnimeRepository, AnimeRepository>();

        return services;
    }

    public static IServiceCollection AddHangfireInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHangfire(cfg => 
                cfg
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("Hangfire"))
            )
            .AddHangfireServer();

        return services;
    }
}