using Animeland.Domain;
using Microsoft.EntityFrameworkCore;

namespace Animeland.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<Anime> Animes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }
    }
}
