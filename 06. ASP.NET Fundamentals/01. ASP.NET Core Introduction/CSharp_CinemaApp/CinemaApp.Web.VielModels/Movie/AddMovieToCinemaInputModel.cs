using CinemaApp.Web.ViewModels.Cinema;
using System.ComponentModel.DataAnnotations;

using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Web.ViewModels.Movie;

public class AddMovieToCinemaInputModel
{
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    [MaxLength(TitleMaxLength)]
    public string MovieTitle { get; set; } = string.Empty;

    public IList<CinemaCheckBoxInputModel> Cinemas { get; set; }
    =new List<CinemaCheckBoxInputModel>();
}
