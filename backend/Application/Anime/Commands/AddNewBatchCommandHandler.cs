using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using MediatR;

namespace Application.Anime.Commands;

public class AddNewAnimeBatchCommandHandler(IAnimeRepository animeRepository, IAniListService aniListService) : IRequestHandler<AddNewAnimeBatchCommand, bool>
{

    private readonly IAnimeRepository _animeRepository = animeRepository ?? throw new ArgumentNullException(nameof(animeRepository));

    private readonly IAniListService _aniListService = aniListService ?? throw new ArgumentNullException(nameof(aniListService));

    public async Task<bool> Handle(AddNewAnimeBatchCommand request, CancellationToken cancellationToken)
    {
        var count = await _animeRepository.GetCountAsync(cancellationToken);

        if (count != 0 && count % 50 != 0)
        {
            return false;
        }

        var page = count != 0 ? count / 50 + 1 : 1;

        try
        {
            var animes = await _aniListService.GetAnimeListAsync(page, cancellationToken);

            if (animes.Count == 0)
            {
                return true;
            }

            await _animeRepository.AddAsync(animes, cancellationToken);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}