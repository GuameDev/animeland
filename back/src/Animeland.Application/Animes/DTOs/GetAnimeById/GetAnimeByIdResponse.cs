namespace Animeland.Application.Animes.DTOs.GetAnimeById
{
    public record GetAnimeByIdResponse(int Id, string Title, string Description, string Genre, int TotalSeasons, int TotalEpisodes, string? CoverImageUrl, DateTime ReleaseDate, string Status);
}
