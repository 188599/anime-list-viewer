using Domain.Common.Models;

namespace Domain.AggregatesModel.AnimeAggregate;

public class Anime : Entity, IAggregateRoot
{
    public required AnimeTitle Title { get; init; }
    public required string? Description { get; init; }
    public required int? SeasonYear { get; init; }
    public required MediaSeason? Season { get; init; }
    public required string[] Genres { get; init; }
    public required MediaStatus? Status { get; init; }
    public required MediaType? Source { get; init; }
    public required int? AverageScore { get; init; }
    public required int? EpisodeCount { get; init; }
    public required int? Duration { get; init; }
    public required string? ImageUrl { get; init; }
}