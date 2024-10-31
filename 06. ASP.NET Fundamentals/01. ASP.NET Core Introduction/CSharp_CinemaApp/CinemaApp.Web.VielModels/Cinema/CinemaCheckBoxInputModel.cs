namespace CinemaApp.Web.ViewModels.Cinema;

using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.Cinema;

public class CinemaCheckBoxInputModel
{
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    [MinLength(NameMinLength)]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = string.Empty ;

    public bool IsSelected { get; set; }
}
