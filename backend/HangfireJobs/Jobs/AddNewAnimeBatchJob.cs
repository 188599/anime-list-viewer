using Application.Anime.Commands;
using HangfireJobs.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HangfireJobs.Jobs;

public class AddNewAnimeBatchJob(ILogger<AddNewAnimeBatchJob> logger, ISender mediator) : IAddNewAnimeBatchJob
{

    public async Task<bool> ExecuteAsync()
    {
        logger.LogInformation("Executing AddNewAnimeBatchJob at {Time}", DateTimeOffset.Now);

        var result = await mediator.Send(new AddNewAnimeBatchCommand());

        logger.LogInformation("AddNewAnimeBatchJob completed with result: {Result}", result);

        return result;
    }
}