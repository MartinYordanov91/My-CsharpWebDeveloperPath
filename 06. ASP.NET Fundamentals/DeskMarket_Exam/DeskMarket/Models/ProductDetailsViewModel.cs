namespace DeskMarket.Models;

public class ProductDetailsViewModel
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public string Seller { get; set; } = null!;
    public string AddedOn { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public bool IsSeller { get; set; }
    public bool HasBought { get; set; }
}
