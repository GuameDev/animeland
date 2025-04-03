using Animeland.Application.Animes.DTOs.GetAnimeById;

namespace Animeland.Application.Animes.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepository _animeRepository;

        public AnimeService(IAnimeRepository animeRepository)
        {
            this._animeRepository = animeRepository;
        }

        public GetAnimeByIdResponse GetAanimeByIdAsync(GetAnimeByIdRequest request)
        {
            var anime = _animeRepository.GetById(request.Id);

            if (anime is null) throw new KeyNotFoundException();

            return new GetAnimeByIdResponse(anime.Id,
                anime.Title,
                anime.Description,
                anime.Genre.Name,
                anime.TotalSeasons,
                anime.TotalSeasons,
                anime.CoverImageUrl,
                anime.ReleaseDate,
                anime.Status.ToString());
        }
    }
}
