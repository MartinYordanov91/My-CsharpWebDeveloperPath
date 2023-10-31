using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private double overallRating;
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            players = new List<IPlayer>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get => pointsEarned;
            private set => pointsEarned = value;
        }

        public double OverallRating
            => overallRating = players.Any() ? Math.Round(players.Average(x => x.Rating), 2) : 0;

        public IReadOnlyCollection<IPlayer> Players
            => players.AsReadOnly();
        public void Draw()
        {
            pointsEarned += 1;
            players.FirstOrDefault(x => x.GetType().Name == "Goalkeeper").IncreaseRating();
        }

        public void Lose()
        {
            players.ForEach(x => x.DecreaseRating());
        }

        public void SignContract(IPlayer player)
        {
            player.JoinTeam(this.name);
            players.Add(player);
        }

        public void Win()
        {
            pointsEarned += 3;
            players.ForEach(x => x.IncreaseRating());
        }

        public override string ToString()
            => $"Team: {Name} Points: {PointsEarned}{Environment.NewLine}--Overall rating: {OverallRating}{Environment.NewLine}--Players: {(players.Any() ? string.Join(", ", players.Select(x=>x.Name)) : "none")}";
    }
}
