using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Data.Configoration;

public class MoviConfigoration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(TitleMaxLength);

        builder.Property(x => x.Genre)
            .IsRequired()
            .HasMaxLength(GenreMaxLength);

        builder.Property(x => x.Director)
            .IsRequired()
            .HasMaxLength(DirectorNameMaxLength);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(DescriptionMaxLength);

        builder.HasData(this.SeedMovies());
    }

    private List<Movie> SeedMovies()
    {
        List<Movie> movies = new List<Movie>()
        {
            new Movie()
            {
                Title = "Oppenheimer",
                Genre = "Drama",
                ReleaseDate = new DateTime(2023, 05, 21),
                Director = "Emma Thomas, Charles Roven",
                Duration = 180,
                Description="A historical drama directed by Christopher Nolan, the film follows the life of physicist J. Robert Oppenheimer, the scientist behind the creation of the atomic bomb. The movie explores both the scientific breakthroughs and the moral dilemmas he faced during the Manhattan Project."
            },

            new Movie()
            {
                Title = "Barbie",
                Genre = "Comedy ",
                ReleaseDate = new DateTime(2023, 05, 21),
                Director = "Margot Robbie, Tom Ackerley, David Heyman",
                Duration = 114 ,
                Description="A satirical comedy that tells the story of the iconic doll Barbie, who leaves her perfect world of Barbieland to discover her identity in the real world. Directed by Greta Gerwig, the film offers a fresh and unexpected take on one of the world’s most famous toys."
            },

            new Movie()
            {
                Title = "Dune: Part Two",
                Genre = "Action",
                ReleaseDate = new DateTime(2024, 03, 15),
                Director = "Mary Parent, Cale Boyter, Denis Villeneuve",
                Duration = 150 ,
                Description="The sequel to the epic sci-fi adaptation of Frank Herbert's novel. Paul Atreides continues his journey to control the desert planet Arrakis, facing new enemies and making fateful decisions. The movie promises even greater scale and deeper character exploration."
            },

            new Movie()
            {
                Title = "Avatar: The Way of Water",
                Genre = "Fantasy",
                ReleaseDate = new DateTime(2022, 12, 16),
                Director = "James Cameron, Jon Landau",
                Duration = 192,
                Description="The sequel to James Cameron’s groundbreaking 2009 film \"Avatar\" follows Jake Sully and his family as they protect Pandora from a new threat. The film is visually stunning and expands on Pandora's underwater world, pushing the limits of cinematic technology."
            },

            new Movie()
            {
                Title = "Mission: Impossible – Dead Reckoning Part One",
                Genre = "Action",
                ReleaseDate = new DateTime(2023, 05, 12),
                Director = "Tom Cruise, Christopher McQuarrie",
                Duration = 163,
                Description="Tom Cruise returns as Ethan Hunt in this latest mission, which sees him face a mysterious global threat. The film delivers high-octane action, intense suspense, and the spectacular stunts that the franchise is known for."
            },

        };

        return movies;
    }
}
