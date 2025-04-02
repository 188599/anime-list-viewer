using Domain.Common.Models;

namespace Domain.AggregatesModel.AnimeAggregate;

public class MediaType(int id, string name, params string[] aliases) : Enumeration(id, name, aliases)
{

    public readonly static MediaType Original = new(1, nameof(Original));
    public readonly static MediaType Manga = new(2, nameof(Manga));
    public readonly static MediaType LightNovel = new(3, nameof(LightNovel), "LIGHT_NOVEL");
    public readonly static MediaType VisualNovel = new(4, nameof(VisualNovel), "VISUAL_NOVEL");
    public readonly static MediaType VideoGame = new(5, nameof(VideoGame), "VIDEO_GAME");
    public readonly static MediaType Other = new(6, nameof(Other));
    public readonly static MediaType Novel = new(7, nameof(Novel));
    public readonly static MediaType Doujinshi = new(8, nameof(Doujinshi));
    public readonly static MediaType Anime = new(9, nameof(Anime));
    public readonly static MediaType WebNovel = new(10, nameof(WebNovel), "WEB_NOVEL");
    public readonly static MediaType LiveAction = new(11, nameof(LiveAction), "LIVE_ACTION");
    public readonly static MediaType Game = new(12, nameof(Game));
    public readonly static MediaType Comic = new(13, nameof(Comic));
    public readonly static MediaType MultimediaProject = new(14, nameof(MultimediaProject), "MULTIMEDIA_PROJECT");
    public readonly static MediaType PictureBook = new(15, nameof(PictureBook), "PICTURE_BOOK");

}

