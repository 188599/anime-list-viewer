using Application.Common.Interfaces.Persistence;
using MediatR;

namespace Application.Anime.Queries;

public class GenresQueryHandler(IAnimeRepository animeRepository) : IRequestHandler<GenresQuery, ICollection<string>>
{
    public async Task<ICollection<string>> Handle(GenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await animeRepository.GetGenresAsync(cancellationToken);
        
        return genres;
    }
}