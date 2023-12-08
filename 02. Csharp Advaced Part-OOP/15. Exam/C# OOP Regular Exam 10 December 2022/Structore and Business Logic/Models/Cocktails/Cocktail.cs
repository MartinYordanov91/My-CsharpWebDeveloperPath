namespace ChristmasPastryShop.Models.Cocktails
{
    using Contracts;
    using System;

    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
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

        public string Size
        {
            get => size;
            private set
            {
                size = value;
            }
        }

        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Middle")
                {
                    value *= 0.6666;
                }
                else if( Size == "Small")
                {
                    value *= 0.3333;
                }
                price = Math.Round(value,2);
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
