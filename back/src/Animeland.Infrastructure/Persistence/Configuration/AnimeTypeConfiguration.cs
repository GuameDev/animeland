using Animeland.Domain.Entities;
using Animeland.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Animeland.Infrastructure.Persistence.Configuration
{
    public class AnimeConfiguration : EntityConfiguration<Anime>
    {
        public override void Configure(EntityTypeBuilder<Anime> builder)
        {
            base.Configure(builder);

            builder.ToTable("Animes");

            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.CoverImageUrl).HasMaxLength(500);
            builder.Property(a => a.ReleaseDate).IsRequired();
            builder.Property(a => a.Status).HasConversion<string>().IsRequired();

            builder.HasOne(a => a.Genre)
                   .WithMany()
                   .HasForeignKey("GenreId")
                   .IsRequired();


            builder.HasData(
                new Anime
                {
                    Id = 1,
                    Title = "Attack on Titan",
                    Description = "Humans fight for survival against man-eating Titans.",
                    TotalSeasons = 4,
                    TotalEpisodes = 87,
                    ReleaseDate = new DateTime(2013, 4, 6),
                    Status = AnimeStatus.Finished,
                    CoverImageUrl = "https://static.wikia.nocookie.net/shingeki-no-kyojin/images/5/53/Primera_temporada_%28parte_1%29.png/revision/latest?cb=20181015211526&path-prefix=es",
                    GenreId = 1,
                    CreatedAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc),
                    UpdateAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc)

                },
                new Anime
                {
                    Id = 2,
                    Title = "Jujutsu Kaisen",
                    Description = "A high school student joins a secret organization to fight curses.",
                    TotalSeasons = 2,
                    TotalEpisodes = 47,
                    ReleaseDate = new DateTime(2020, 10, 3),
                    Status = AnimeStatus.OnAir,
                    CoverImageUrl = "https://image.api.playstation.com/vulcan/ap/rnd/202309/2817/001971fa2fc21d37b7c0d3e9cb45b2a651252d455e90a764.png",
                    GenreId = 1,
                    CreatedAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc),
                    UpdateAt = new DateTime(2025, 04, 03, 22, 30, 00, DateTimeKind.Utc)

                }
);

        }
    }
}
