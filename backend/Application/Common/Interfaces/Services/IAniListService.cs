namespace Application.Common.Interfaces.Services;

using Anime = Domain.AggregatesModel.AnimeAggregate.Anime;

public interface IAniListService
{
    Task<ICollection<Anime>> GetAnimeListAsync(int? Page, CancellationToken cancellationToken);
}