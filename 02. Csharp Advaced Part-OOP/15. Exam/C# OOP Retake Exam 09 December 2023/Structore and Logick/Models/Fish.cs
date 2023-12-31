﻿namespace NauticalCatchChallenge.Models
{
    using Contracts;
    public abstract class Fish : IFish
    {
        private string name;
        private double points;
        private int timeToCatch;

        protected Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name should be determined.");
                }
                name = value;
            }
        }

        public double Points
        {
            get => points;
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Points must be a numeric value, between 1 and 10.");
                }
                points = value;
            }
        }

        public int TimeToCatch
        {
            get => timeToCatch;
            private set
            {
                timeToCatch = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
