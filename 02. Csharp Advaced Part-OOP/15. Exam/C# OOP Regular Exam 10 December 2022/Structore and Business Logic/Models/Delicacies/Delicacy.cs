namespace ChristmasPastryShop.Models.Delicacies
{
    using System;
    using Contracts;

    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        protected Delicacy(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double Price
        {
            get => price;
            private set
            {
                price = Math.Round(value , 2);
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Price:f2} lv";
        }
    }
}
