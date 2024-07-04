using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Player
{
    public Player()
    {
        this.PlayersStatistics = new HashSet<PlayerStatistic>();
    }

    [Key]
    public int PlayerId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public int SquadNumber { get; set; }

    public bool IsInjured { get; set; }

    public int PositionId { get; set; }

    public virtual Position Position { get; set; } = null!;

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    public int TownId { get; set; }

    public virtual Town Town { get; set; }

    [InverseProperty("Player")]
    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }

}
