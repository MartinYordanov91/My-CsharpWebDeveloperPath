﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Game
{
    public Game()
    {
        this.PlayersStatistics = new HashSet<PlayerStatistic>();
        this.Bets = new HashSet<Bet>();
    }

    [Key]
    public int GameId { get; set; }

    public int HomeTeamId { get; set; }

    [InverseProperty("HomeGames")]
    public virtual Team HomeTeam { get; set; } = null!;

    public int AwayTeamId { get; set; }

    [InverseProperty("AwayGames")]
    public virtual Team AwayTeam { get; set; } = null!;

    public int HomeTeamGoals { get; set; }

    public int AwayTeamGoals { get; set; }

    public decimal HomeTeamBetRate { get; set; }

    public decimal AwayTeamBetRate { get; set; }

    public decimal DrawBetRate { get; set; }

    public DateTime DateTime { get; set; }

    [MaxLength(10)]
    public string? Result { get; set; }

    [InverseProperty("Game")]
    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }

    [InverseProperty("Game")]
    public virtual ICollection<Bet> Bets { get; set; }
}
