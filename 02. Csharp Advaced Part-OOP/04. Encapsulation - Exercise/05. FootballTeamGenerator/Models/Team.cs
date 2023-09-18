using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private readonly List<Player> teams;
        private string name;

        public Team(string name)
        {
            Name = name;
            teams = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException("A name should not be empty.");
                }
                name = value;
            }
        }
        public double Rating
        {
            get
            {
                double rating = 0;
                foreach (Player p in teams)
                {
                    rating += p.Stats;
                }
                if (teams.Any() == false)
                {
                    return 0;
                }
                return (rating / 5) / teams.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            teams.Add(player);
        }
        public void RemovePlayer(string name)
        {
            if (teams.Any(p => p.Name == name) == false)
            {
                throw new AggregateException($"Player {name} is not in {Name} team.");
            }

            teams.Remove(teams.FirstOrDefault(n => n.Name == name));
        }

        public override string ToString() => $"{Name} - {Rating:f0}";

    }
}
