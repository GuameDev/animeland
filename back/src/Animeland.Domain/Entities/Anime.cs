using Animeland.Domain.Enums;

namespace Animeland.Domain.Entities
{
    public class Anime : Entity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = default!;
        public int TotalSeasons { get; set; }
        public int TotalEpisodes { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public AnimeStatus Status { get; set; }
    }

}
