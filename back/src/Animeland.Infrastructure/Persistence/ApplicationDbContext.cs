using Animeland.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Animeland.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly AuditInterceptor _auditInterceptor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            AuditInterceptor auditInterceptor) : base(options)
        {
            _auditInterceptor = auditInterceptor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditInterceptor);
        }
    }
}
