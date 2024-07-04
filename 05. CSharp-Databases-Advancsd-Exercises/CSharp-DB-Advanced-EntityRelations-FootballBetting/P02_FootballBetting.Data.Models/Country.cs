using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Country
{
    public Country()
    {
        this.Towns = new HashSet<Town>();
    }

    public int CountryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Country")]
    public virtual ICollection<Town> Towns { get; set; }

}
