using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Data.Models;

public class ProductClient
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    public Product Product { get; set; } = null!;

    [Required]
    public string ClientId { get; set; } = null!;

    [Required]
    public IdentityUser Client { get; set; } = null!;
}

//ProductCategory
//    • Has ProductId – integer, PrimaryKey, foreign key(required)
//    • Has Product – Product
//    • Has ClientId – string, PrimaryKey, foreign key(required)
//    • Has Client – IdentityUser