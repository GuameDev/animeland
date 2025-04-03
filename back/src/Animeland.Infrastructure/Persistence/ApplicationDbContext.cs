using Animeland.Domain.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
