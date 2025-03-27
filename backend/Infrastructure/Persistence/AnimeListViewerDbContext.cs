using Domain.AggregatesModel.AnimeAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AnimeListViewerDbContext(DbContextOptions<AnimeListViewerDbContext> options) : DbContext(options)
{

    public DbSet<Anime> Animes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimeListViewerDbContext).Assembly);
    }
}