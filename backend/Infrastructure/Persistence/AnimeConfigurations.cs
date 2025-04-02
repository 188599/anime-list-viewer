using Domain.AggregatesModel.AnimeAggregate;
using Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence;

public class AnimeConfigurations : IEntityTypeConfiguration<Anime>
{
    public void Configure(EntityTypeBuilder<Anime> builder)
    {
        ConfigureAnimesTable(builder);
    }

    private static void ConfigureAnimesTable(EntityTypeBuilder<Anime> builder)
    {
        builder.ToTable("Animes");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedNever();
        builder.OwnsOne(a => a.Title, t =>
        {
            t.Property(t => t.English);
            t.Property(t => t.Native);
            t.Property(t => t.Romaji);
        });
        builder.Property(a => a.Description);
        builder.Property(a => a.SeasonYear);
        builder.Property(a => a.Season).HasConversion(s => s!.Id, id => Enumeration.FromValue<MediaSeason>(id));
        builder.Property(a => a.Genres);
        builder.Property(a => a.Status).HasConversion(s => s!.Id, id => Enumeration.FromValue<MediaStatus>(id));
        builder.Property(a => a.Source).HasConversion(s => s!.Id, id => Enumeration.FromValue<MediaType>(id));
        builder.Property(a => a.AverageScore);
        builder.Property(a => a.EpisodeCount);
        builder.Property(a => a.Duration);
        builder.Property(a => a.ImageUrl);
    }
}