using Animeland.Application.Animes.DTOs.GetAnimeById;

namespace Animeland.Application.Animes.Services
{
    public interface IAnimeService
    {
        GetAnimeByIdResponse GetAanimeByIdAsync(GetAnimeByIdRequest request);
    }
}
