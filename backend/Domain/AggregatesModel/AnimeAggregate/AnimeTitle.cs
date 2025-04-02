namespace Domain.AggregatesModel.AnimeAggregate;

public record AnimeTitle
{
    public required string? English { get; init; }
    public required string? Native { get; init; }
    public required string? Romaji { get; init; }
}