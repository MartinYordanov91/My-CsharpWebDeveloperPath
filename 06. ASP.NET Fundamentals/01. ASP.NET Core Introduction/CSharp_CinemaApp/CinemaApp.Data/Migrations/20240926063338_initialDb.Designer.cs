﻿// <auto-generated />
using System;
using CinemaApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20240926063338_initialDb")]
    partial class initialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CinemaApp.Data.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d620c527-9fc0-4d23-8987-4d350022cf85"),
                            Description = "A historical drama directed by Christopher Nolan, the film follows the life of physicist J. Robert Oppenheimer, the scientist behind the creation of the atomic bomb. The movie explores both the scientific breakthroughs and the moral dilemmas he faced during the Manhattan Project.",
                            Director = "Emma Thomas, Charles Roven",
                            Duration = 180,
                            Genre = "Drama",
                            ReleaseDate = new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Oppenheimer"
                        },
                        new
                        {
                            Id = new Guid("aee53c03-baa6-4af8-aafb-d9875b2ae97f"),
                            Description = "A satirical comedy that tells the story of the iconic doll Barbie, who leaves her perfect world of Barbieland to discover her identity in the real world. Directed by Greta Gerwig, the film offers a fresh and unexpected take on one of the world’s most famous toys.",
                            Director = "Margot Robbie, Tom Ackerley, David Heyman",
                            Duration = 114,
                            Genre = "Comedy ",
                            ReleaseDate = new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Barbie"
                        },
                        new
                        {
                            Id = new Guid("3828e88e-1f3c-4bdd-a261-4eef739aa75c"),
                            Description = "The sequel to the epic sci-fi adaptation of Frank Herbert's novel. Paul Atreides continues his journey to control the desert planet Arrakis, facing new enemies and making fateful decisions. The movie promises even greater scale and deeper character exploration.",
                            Director = "Mary Parent, Cale Boyter, Denis Villeneuve",
                            Duration = 150,
                            Genre = "Action",
                            ReleaseDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Dune: Part Two"
                        },
                        new
                        {
                            Id = new Guid("3a112f31-4e84-4610-bb5e-43b65c86ea0c"),
                            Description = "The sequel to James Cameron’s groundbreaking 2009 film \"Avatar\" follows Jake Sully and his family as they protect Pandora from a new threat. The film is visually stunning and expands on Pandora's underwater world, pushing the limits of cinematic technology.",
                            Director = "James Cameron, Jon Landau",
                            Duration = 192,
                            Genre = "Fantasy",
                            ReleaseDate = new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avatar: The Way of Water"
                        },
                        new
                        {
                            Id = new Guid("ac9847ff-9f96-4805-814a-b80d87213e6b"),
                            Description = "Tom Cruise returns as Ethan Hunt in this latest mission, which sees him face a mysterious global threat. The film delivers high-octane action, intense suspense, and the spectacular stunts that the franchise is known for.",
                            Director = "Tom Cruise, Christopher McQuarrie",
                            Duration = 163,
                            Genre = "Action",
                            ReleaseDate = new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mission: Impossible – Dead Reckoning Part One"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
