using Animeland.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Animeland.Infrastructure.Persistence.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");

            builder.Property(g => g.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Shonen",
                    CreatedAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc),
                    UpdateAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc)
                },
                new Genre
                {
                    Id = 2,
                    Name = "Seinen",
                    CreatedAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc),
                    UpdateAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc)
                },
                new Genre
                {
                    Id = 3,
                    Name = "Shojo",
                    CreatedAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc),
                    UpdateAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc)
                }
);
        }
    }
}