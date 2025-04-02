using Application.Common.Interfaces.Persistence;
using MediatR;

namespace Application.Anime.Queries;

public class AnimeQueryHandler(IAnimeRepository animeRepository) : IRequestHandler<AnimeQuery, ICollection<AnimeDTO>>
{
    public async Task<ICollection<AnimeDTO>> Handle(AnimeQuery request, CancellationToken cancellationToken)
    {
        int? filterByMinScore = null;
        int? filterByMaxScore = null;
        
        if (!string.IsNullOrEmpty(request.FilterByScore))
        {
            var score = request.FilterByScore.Split('-');
            if (score.Length > 0)
            {
                filterByMinScore = int.Parse(score[0]);
                if (score.Length > 1) 
                {
                    filterByMaxScore = int.Parse(score[1]);
                }
            }
        }

        var animes = await animeRepository.GetListAsync(request.FilterByTitle, request.FilterByGenre, request.FilterByYear, filterByMinScore, filterByMaxScore, cancellationToken);
        
        return [.. animes.Select(anime => new AnimeDTO(
            anime.Id,
            anime.Title,
            anime.Description,
            anime.SeasonYear,
            anime.Season?.ToString(),
            anime.Genres,
            anime.Status?.ToString(),
            anime.Source?.ToString(),
            anime.AverageScore,
            anime.EpisodeCount,
            anime.Duration,
            anime.ImageUrl
        ))];
    }
}