namespace HangfireJobs.Interfaces;

public interface IAddNewAnimeBatchJob
{
    Task<bool> ExecuteAsync();
}