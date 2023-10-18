using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        private string name;
        private int openPositions;
        private char group;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public List<Player> Players
        {
            get => players;
            set { players = value; }
        }
        public string Name
        {
            get => name;
            set { name = value; }
        }

        public int OpenPositions
        {
            get => openPositions;
            set { openPositions = value; }
        }

        public char Group
        {
            get => group;
            set { group = value; }
        }

        public int Count
        {
            get => players.Count;
        }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";

            }

            if (openPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);
            OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            if (players.Any(x => x.Name == name))
            {
                OpenPositions++;
                players.Remove(players.FirstOrDefault(x => x.Name == name));
                return true;
            }
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int remPLayer = players.RemoveAll(x => x.Position == position);
            OpenPositions += remPLayer;
            return remPLayer;
        }

        public Player RetirePlayer(string name)
        {
            if (players.Any(x => x.Name == name))
            {
                players.Find(x => x.Name == name).Retired = true;
                return players.Find(x => x.Name == name);
            }
            return null;
        }

        public List<Player> AwardPlayers(int games)
            => Players.Where(x => x.Games >= games).ToList();

        
        public string Report()
           => $"Active players competing for Team {this.Name} from Group {this.Group}:{Environment.NewLine}{string.Join(Environment.NewLine, this.Players.Where(p => !p.Retired))}";
    }
}
