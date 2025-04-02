using Domain.Common.Models;

namespace Domain.AggregatesModel.AnimeAggregate;

public class MediaStatus(int id, string name, params string[] aliases) : Enumeration(id, name, aliases)
{
    public static readonly MediaStatus Finished = new(1, nameof(Finished));
    public static readonly MediaStatus Releasing = new(2, nameof(Releasing));
    public static readonly MediaStatus NotYetReleased = new(3, nameof(NotYetReleased), "NOT_YET_RELEASED");
    public static readonly MediaStatus Cancelled = new(4, nameof(Cancelled));
    public static readonly MediaStatus Hiatus = new(5, nameof(Hiatus));
}
