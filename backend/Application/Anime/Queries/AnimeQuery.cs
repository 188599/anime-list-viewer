using MediatR;

namespace Application.Anime.Queries;

public record AnimeQuery(
    string? FilterByTitle,
    string[] FilterByGenre,
    int? FilterByYear,
    string? FilterByScore
) : IRequest<ICollection<AnimeDTO>>;
