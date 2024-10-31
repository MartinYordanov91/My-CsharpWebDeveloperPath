using DeskMarket.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Models;

public class ProductViewModel
{
    public int Id { get; set; }
    public string? ImageUrl { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsSeller { get; set; }
    public bool HasBought { get; set; }
}
