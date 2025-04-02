using Hangfire;
using HangfireJobs;
using HangfireJobs.Interfaces;
using Infrastructure;

var builder = Host.CreateApplicationBuilder(args);
builder.Services
    .AddHangfireJobs()
    .AddInfrastructure(builder.Configuration)
    .AddHangfireInfrastructure(builder.Configuration);

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    recurringJobManager.AddOrUpdate<IAddNewAnimeBatchJob>(nameof(IAddNewAnimeBatchJob), job => job.ExecuteAsync(), Cron.Hourly());
}


host.Run();

