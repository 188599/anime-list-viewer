
namespace Application.Common.Interfaces.Persistence;

using Anime = Domain.AggregatesModel.AnimeAggregate.Anime;

public interface IAnimeRepository
{
    public Task AddAsync(ICollection<Anime> animes, CancellationToken cancellationToken);
    public Task<int> GetCountAsync(CancellationToken cancellationToken);
    public Task<ICollection<string>> GetGenresAsync(CancellationToken cancellationToken);
    public Task<ICollection<Anime>> GetListAsync(
        string? filterByTitle,
        string[] filterByGenre,
        int? filterByYear,
        int? filterByMinScore,
        int? filterByMaxScore,
        CancellationToken cancellationToken
    );
}