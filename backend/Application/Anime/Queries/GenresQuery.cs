using MediatR;

namespace Application.Anime.Queries;

public record GenresQuery() : IRequest<ICollection<string>>;