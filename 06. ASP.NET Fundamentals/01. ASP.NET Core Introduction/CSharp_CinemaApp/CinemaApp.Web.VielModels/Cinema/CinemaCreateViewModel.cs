using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.Cinema;
namespace CinemaApp.Web.ViewModels.Cinema;

public class CinemaCreateViewModel
{
    [Required]
    [MinLength(NameMinLength)]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = string.Empty;


    [Required]
    [MaxLength(LocationMaxLength)]
    [MinLength(LocationMinLength)]
    public string Location { get; set; } = string.Empty;
}
