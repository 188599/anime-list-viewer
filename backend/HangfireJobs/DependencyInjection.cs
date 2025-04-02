using Application;
using HangfireJobs.Interfaces;
using HangfireJobs.Jobs;
using Microsoft.Extensions.DependencyInjection;

namespace HangfireJobs;

public static class DependencyInjection
{
    public static IServiceCollection AddHangfireJobs(this IServiceCollection services)
    {
        services.AddScoped<IAddNewAnimeBatchJob, AddNewAnimeBatchJob>()
            .AddApplication();

        return services;
    }
}