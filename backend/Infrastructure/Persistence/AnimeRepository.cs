using Application.Common.Interfaces.Persistence;
using Domain.AggregatesModel.AnimeAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AnimeRepository(AnimeListViewerDbContext context) : IAnimeRepository
{
    private readonly AnimeListViewerDbContext _context = context;

    public async Task AddAsync(ICollection<Anime> animes, CancellationToken cancellationToken)
    {
        await _context.Animes.AddRangeAsync(animes, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<IEnumerable<Anime>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Animes.ToListAsync(cancellationToken);
    }

}