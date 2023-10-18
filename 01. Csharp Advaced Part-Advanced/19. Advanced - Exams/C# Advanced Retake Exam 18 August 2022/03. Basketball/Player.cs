using System;
using System.Collections.Generic;
using System.Text;

namespace Basketball
{
    public class Player
    {
        private string name;
        private string position;
        private double rating;
        private int games;
        private bool retired;

        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
            Retired = false;
        }

        public string Name
        {
            get => name;
            set { name = value; }
        }

        public string Position
        {
            get => position;
            set { position = value; }
        }

        public double Rating
        {
            get => rating;
            set { rating = value; }
        }

        public int Games
        {
            get => games;
            set { games = value; }
        }

        public bool Retired
        {
            get => retired;
            set { retired = value; }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"-Player: {Name}");
            stringBuilder.AppendLine($"--Position: {Position}");
            stringBuilder.AppendLine($"--Rating: {Rating}");
            stringBuilder.AppendLine($"--Games played: {Games}");
            
            return stringBuilder.ToString().Trim();
        }
    }
}
