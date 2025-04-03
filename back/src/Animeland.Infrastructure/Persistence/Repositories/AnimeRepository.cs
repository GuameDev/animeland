using Animeland.Application.Animes;
using Animeland.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Animeland.Infrastructure.Persistence.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly ApplicationDbContext _context;

        public AnimeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Anime? GetById(int id)
        {
            var query = _context.Set<Anime>().AsQueryable();

            return query
                .Include(x => x.Genre)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
