using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("3828e88e-1f3c-4bdd-a261-4eef739aa75c"), "The sequel to the epic sci-fi adaptation of Frank Herbert's novel. Paul Atreides continues his journey to control the desert planet Arrakis, facing new enemies and making fateful decisions. The movie promises even greater scale and deeper character exploration.", "Mary Parent, Cale Boyter, Denis Villeneuve", 150, "Action", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dune: Part Two" },
                    { new Guid("3a112f31-4e84-4610-bb5e-43b65c86ea0c"), "The sequel to James Cameron’s groundbreaking 2009 film \"Avatar\" follows Jake Sully and his family as they protect Pandora from a new threat. The film is visually stunning and expands on Pandora's underwater world, pushing the limits of cinematic technology.", "James Cameron, Jon Landau", 192, "Fantasy", new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar: The Way of Water" },
                    { new Guid("ac9847ff-9f96-4805-814a-b80d87213e6b"), "Tom Cruise returns as Ethan Hunt in this latest mission, which sees him face a mysterious global threat. The film delivers high-octane action, intense suspense, and the spectacular stunts that the franchise is known for.", "Tom Cruise, Christopher McQuarrie", 163, "Action", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mission: Impossible – Dead Reckoning Part One" },
                    { new Guid("aee53c03-baa6-4af8-aafb-d9875b2ae97f"), "A satirical comedy that tells the story of the iconic doll Barbie, who leaves her perfect world of Barbieland to discover her identity in the real world. Directed by Greta Gerwig, the film offers a fresh and unexpected take on one of the world’s most famous toys.", "Margot Robbie, Tom Ackerley, David Heyman", 114, "Comedy ", new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbie" },
                    { new Guid("d620c527-9fc0-4d23-8987-4d350022cf85"), "A historical drama directed by Christopher Nolan, the film follows the life of physicist J. Robert Oppenheimer, the scientist behind the creation of the atomic bomb. The movie explores both the scientific breakthroughs and the moral dilemmas he faced during the Manhattan Project.", "Emma Thomas, Charles Roven", 180, "Drama", new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oppenheimer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
