using Domain.AggregatesModel.AnimeAggregate;

namespace Application.Common.Interfaces.Persistence;

public interface IAnimeRepository
{
    public Task<IEnumerable<Anime>> GetAllAsync(CancellationToken cancellationToken);
    public Task AddAsync(ICollection<Anime> animes, CancellationToken cancellationToken);
}