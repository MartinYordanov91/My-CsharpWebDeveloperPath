using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private double rating;
        private string team;

        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                name = value;
            }
        }

        public double Rating
        {
            get => rating;
            protected set => rating = value;
        }

        public string Team
        {
            get => team;
            private set => team = value;
        }

        public abstract void DecreaseRating();


        public abstract void IncreaseRating();

        public void JoinTeam(string name)
            => this.team = name;

        public override string ToString()
            => $"{this.GetType().Name}: {Name}{Environment.NewLine}--Rating: {Rating}";
    }
}
