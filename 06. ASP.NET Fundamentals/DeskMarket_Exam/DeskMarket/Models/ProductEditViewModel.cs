using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Models;

public class ProductEditViewModel
{
    [Required]
    [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public string SellerId { get; set; } = string.Empty;

    [Required]
    [Range(ProductPriceMinValue, ProductPriceMaxValue)]
    public decimal Price { get; set; }

    [Required]
    [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
    public string Description { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    [Required]
    [RegularExpression(@"^\d{2}-\d{2}-\d{4}$")]
    public string AddedOn { get; set; } = string.Empty;

    [Required]
    public int CategoryId { get; set; }

    public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
}
