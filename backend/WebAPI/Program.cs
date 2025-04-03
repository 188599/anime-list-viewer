using Application;
using Application.Anime.Commands;
using Application.Anime.Queries;
using Application.Common.Interfaces.Persistence;
using Infrastructure;
using Infrastructure.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AnimeListViewerDbContext>();

        await context.Database.EnsureCreatedAsync();

        var mediator = services.GetRequiredService<ISender>();

        var animeRepository = services.GetRequiredService<IAnimeRepository>();
        var count = await animeRepository.GetCountAsync(CancellationToken.None);

        if (count == 0)
        {
            var newBatchAdded = await mediator.Send(new AddNewAnimeBatchCommand());

            if (!newBatchAdded)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError("Failed to add new batch.");
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("api/anime/list", async (
    string? filterByTitle,
    string[] filterByGenre,
    int? filterByYear,
    string? filterByScore, ISender mediator) => 
    await mediator.Send(new AnimeQuery(filterByTitle, filterByGenre, filterByYear, filterByScore)));

app.MapGet("api/anime/genres", async (ISender mediator) => await mediator.Send(new GenresQuery()));

app.UseHttpsRedirection();

app.Run();
