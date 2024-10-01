using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Web.ViewModels.Movie;

public class AddMovieInputModel
{
    public AddMovieInputModel()
    {
        this.ReleaseDate = DateTime.UtcNow.ToString(ReleaseDateFormat);
    }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(GenreMaxLength)]
    [MinLength(GenreMinLength)]
    public string Genre { get; set; } = string.Empty;

    [Required]
    public string ReleaseDate { get; set; } 

    [Required]
    [Range(DurationMinValue, DurationMaxValue)]
    public int Duration { get; set; }

    [Required]
    [MinLength(DirectorNameMinLength)]
    [MaxLength(DirectorNameMaxLength)]
    public string Director { get; set; } = string.Empty;

    [Required]
    [MaxLength(DirectorNameMaxLength)]
    [MinLength(DirectorNameMinLength)]
    public string Description { get; set; } = string.Empty;
}
