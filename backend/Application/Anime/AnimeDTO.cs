using Domain.AggregatesModel.AnimeAggregate;

namespace Application.Anime;

public record AnimeDTO(
    int Id,
    AnimeTitle Title,
    string? Description,
    int? SeasonYear,
    string? Season,
    string[] Genres,
    string? Status,
    string? Source,
    int? AverageScore,
    int? EpisodeCount,
    int? Duration,
    string? ImageUrl
);