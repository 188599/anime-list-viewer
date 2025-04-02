using Application.Common.Interfaces.Persistence;
using Domain.AggregatesModel.AnimeAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AnimeRepository(AnimeListViewerDbContext context) : IAnimeRepository
{

    public async Task AddAsync(ICollection<Anime> animes, CancellationToken cancellationToken)
    {
        await context.Animes.AddRangeAsync(animes, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    public async Task<int> GetCountAsync(CancellationToken cancellationToken)
    {
        return await context.Animes.CountAsync(cancellationToken);
    }

    public async Task<ICollection<string>> GetGenresAsync(CancellationToken cancellationToken)
    {
        var genres = await context.Animes
            .SelectMany(a => a.Genres)
            .Distinct()
            .ToListAsync(cancellationToken);

        return genres;
    }

    public async Task<ICollection<Anime>> GetListAsync(string? filterByTitle, string[] filterByGenre, int? filterByYear, int? filterByMinScore, int? filterByMaxScore, CancellationToken cancellationToken)
    {
        var query = context.Animes.AsQueryable();

        if (!string.IsNullOrEmpty(filterByTitle))
        {
            query = query.Where(a => a.Title.Native!.Contains(filterByTitle) || a.Title.English!.Contains(filterByTitle) || a.Title.Romaji!.Contains(filterByTitle));
        }

        if (filterByGenre.Length > 0)
        {
            query = query.Where(a => filterByGenre.Any(g => a.Genres.Contains(g)));
        }

        if (filterByYear.HasValue)
        {
            query = query.Where(a => a.SeasonYear == filterByYear.Value);
        }

        if (filterByMinScore.HasValue)
        {
            query = query.Where(a => a.AverageScore >= filterByMinScore.Value);
        }

        if (filterByMaxScore.HasValue)
        {
            query = query.Where(a => a.AverageScore <= filterByMaxScore.Value);
        }

        return await query.ToListAsync(cancellationToken);
    }
}