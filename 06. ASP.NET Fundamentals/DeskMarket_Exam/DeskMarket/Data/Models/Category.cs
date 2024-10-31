using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ValidationConstants;


namespace DeskMarket.Data.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CategoryNameMaxLength)]
    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();   
}

//Category
//    • Has Id – a unique integer, Primary Key
//    • Has Name – a string with min length 3 and max length 20 (required)
//    • Has Products – a collection of type Product