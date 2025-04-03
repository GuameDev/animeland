using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Animeland.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    TotalSeasons = table.Column<int>(type: "int", nullable: false),
                    TotalEpisodes = table.Column<int>(type: "int", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animes_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc), "Shonen", new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc), "Seinen", new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc), "Shojo", new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "Description", "GenreId", "ReleaseDate", "Status", "Title", "TotalEpisodes", "TotalSeasons", "UpdateAt" },
                values: new object[,]
                {
                    { 1, "https://static.wikia.nocookie.net/shingeki-no-kyojin/images/5/53/Primera_temporada_%28parte_1%29.png/revision/latest?cb=20181015211526&path-prefix=es", new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc), "Humans fight for survival against man-eating Titans.", 1, new DateTime(2013, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finished", "Attack on Titan", 87, 4, new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc) },
                    { 2, "https://image.api.playstation.com/vulcan/ap/rnd/202309/2817/001971fa2fc21d37b7c0d3e9cb45b2a651252d455e90a764.png", new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc), "A high school student joins a secret organization to fight curses.", 1, new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "OnAir", "Jujutsu Kaisen", 47, 2, new DateTime(2025, 4, 3, 22, 30, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_GenreId",
                table: "Animes",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
