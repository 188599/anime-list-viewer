using Domain.SeedWork;

namespace Domain.AggregatesModel.AnimeAggregate;

public class MediaStatus(int id, string name) : Enumeration(id, name)
{
    public static readonly MediaStatus Finished = new(1, nameof(Finished));
    public static readonly MediaStatus Releasing = new(2, nameof(Releasing));
    public static readonly MediaStatus NotYetReleased = new(3, nameof(NotYetReleased));
    public static readonly MediaStatus Cancelled = new(4, nameof(Cancelled));
    public static readonly MediaStatus Hiatus = new(5, nameof(Hiatus));
}
