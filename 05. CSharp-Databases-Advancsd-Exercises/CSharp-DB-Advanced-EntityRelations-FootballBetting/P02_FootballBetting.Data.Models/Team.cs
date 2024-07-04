using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Team
{
    public Team()
    {
         this.HomeGames = new HashSet<Game>();
         this.AwayGames = new HashSet<Game>();
         this.Players = new HashSet<Player>();
    }

    [Key]
    public int TeamId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(256)]
    public string LogoUrl { get; set; } = null!;

    [Required]
    [MaxLength(4)]
    public string Initials { get; set; } = null!;

    [Required]
    public decimal Budget { get; set; }

    public int PrimaryKitColorId { get; set; }

    [InverseProperty("PrimaryKitTeams")]
    public virtual Color PrimaryKitColor { get; set; } = null!;

    public int SecondaryKitColorId { get; set; }

    [InverseProperty("SecondaryKitTeams")]
    public virtual Color SecondaryKitColor { get; set; } = null!;

    public int TownId { get; set; }

    [InverseProperty("Teams")]
    public virtual Town Town { get; set; } = null!;

    [InverseProperty("HomeTeam")]
    public virtual ICollection<Game> HomeGames { get; set; }

    [InverseProperty("AwayTeam")]
    public virtual ICollection<Game> AwayGames { get; set; }

    [InverseProperty("Team")]
    public virtual ICollection<Player> Players { get; set; }
}
