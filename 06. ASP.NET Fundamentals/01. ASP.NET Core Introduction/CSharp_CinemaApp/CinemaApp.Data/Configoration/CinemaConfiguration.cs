using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static CinemaApp.Common.EntityValidationConstants.Cinema;

namespace CinemaApp.Data.Configoration;

public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(NameMaxLength);

        builder
            .Property(x => x.Location)
            .IsRequired()
            .HasMaxLength(LocationMaxLength);

        builder
            .HasData(GenerateCinemas());
    }


    private IEnumerable<Cinema> GenerateCinemas()
    {
        IEnumerable<Cinema> cinemas = new List<Cinema>(){

             new Cinema()
             {
                Name = "Cinema city",
                Location = "Sofia"
             },
             
             new Cinema()
             {
                Name = "Cinema city",
                Location = "Plovdiv"
             },
             
             new Cinema()
             {
                Name = "CinemaX",
                Location = "Varna"
             },

        };


        return cinemas;
    }
}
