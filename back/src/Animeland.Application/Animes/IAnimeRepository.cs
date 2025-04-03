using Animeland.Domain.Entities;

namespace Animeland.Application.Animes
{
    public interface IAnimeRepository
    {
        Anime? GetById(int id);
    }
}
