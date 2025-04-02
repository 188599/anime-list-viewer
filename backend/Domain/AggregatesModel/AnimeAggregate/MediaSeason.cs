using Domain.Common.Models;

namespace Domain.AggregatesModel.AnimeAggregate;

public class MediaSeason(int id, string name) : Enumeration(id, name)
{
    public static readonly MediaSeason Winter = new(1, nameof(Winter));
    public static readonly MediaSeason Spring = new(2, nameof(Spring));
    public static readonly MediaSeason Summer = new(3, nameof(Summer));
    public static readonly MediaSeason Fall = new(4, nameof(Fall));
}