using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Common.Interfaces.Services;
using Domain.AggregatesModel.AnimeAggregate;
using Domain.Common.Models;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Services;

public class AniListService() : IAniListService
{
    private readonly HttpClient _httpClient = new();

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };
    private const string AniListApiUrl = "https://graphql.anilist.co";
    private const string AniListApiQuery = @"
        query Page($sort: [MediaSort], $page: Int, $perPage: Int, $type: MediaType, $genreNotIn: [String]) {
          Page(page: $page, perPage: $perPage) {
            media(sort: $sort, type: $type, genre_not_in: $genreNotIn) {
              id
              title {
                english
                native
                romaji
              }
              description
              seasonYear
              season
              genres
              status
              source
              averageScore
              episodes
              duration
              coverImage {
                large
              }
            }
          }
        }";

    public async Task<ICollection<Anime>> GetAnimeListAsync(int? Page, CancellationToken cancellationToken)
    {
        var query = AniListApiQuery;
        var variables = new
        {
            sort = new[] { "ID" },
            page = Page ?? 1,
            perPage = 50,
            type = "ANIME",
            genreNotIn = new[] { "Hentai" }
        };

        var result = await _httpClient.PostAsJsonAsync(AniListApiUrl, new
        {
            query,
            variables
        }, cancellationToken);

        if (result.IsSuccessStatusCode)
        {
            var contentString = JObject.Parse(await result.Content.ReadAsStringAsync(cancellationToken))["data"]["Page"]["media"].ToString();

            var animes = JsonSerializer.Deserialize<AniListResponse[]?>(contentString, _jsonSerializerOptions);

            animes ??= [];

            return [..animes.Select(anime => new Anime
            {
                Id = anime.Id,
                Title = new AnimeTitle
                {
                    English = anime.Title.English,
                    Native = anime.Title.Native,
                    Romaji = anime.Title.Romaji
                },
                Description = anime.Description,
                SeasonYear = anime.SeasonYear,
                Season = anime.Season is not null ? Enumeration.FromDisplayName<MediaSeason>(anime.Season) : null,
                Genres = anime.Genres ?? [],
                Status = anime.Status is not null ? Enumeration.FromDisplayName<MediaStatus>(anime.Status) : null,
                Source = anime.Source is not null ? Enumeration.FromDisplayName<MediaType>(anime.Source) : null,
                AverageScore = anime.AverageScore,
                EpisodeCount = anime.Episodes,
                Duration = anime.Duration,
                ImageUrl = anime.CoverImage.Large
            })];
        }
        else
        {
            throw new Exception("Failed to fetch data from AniList");
        }
    }

    private record AniListResponse()
    {
        public required int Id { get; init; }
        public required AniListResponseTitle Title { get; init; }
        public required string? Description { get; init; }
        public required int? SeasonYear { get; init; }
        public required string? Season { get; init; }
        public required string[]? Genres { get; init; }
        public required string? Status { get; init; }
        public required string? Source { get; init; }
        public required int? AverageScore { get; init; }
        public required int? Episodes { get; init; }
        public required int? Duration { get; init; }
        public required AniListResponseCoverImage CoverImage { get; init; }
    }

    private record AniListResponseTitle()
    {
        public required string? English { get; init; }
        public required string? Native { get; init; }
        public required string? Romaji { get; init; }
    }

    private record AniListResponseCoverImage()
    {
        public required string? Large { get; init; }
    }

}


