using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace P02_FootballBetting.Data.Models;

public class Town
{
    public Town()
    {
        this.Teams = new HashSet<Team>();
    }

    public int TownId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual Country Country { get; set; }

    [InverseProperty("Town")]
    public virtual ICollection<Team> Teams { get; set; }

    [InverseProperty("Town")]
    public virtual ICollection<Player> Players{ get; set; }
}
