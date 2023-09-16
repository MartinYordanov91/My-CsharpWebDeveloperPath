using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private const int MinMoney = 0;

        private string name;
        private decimal money;
        private readonly List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < MinMoney)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public void AddInBag(Product product)
        {
            if (product.Cost > Money)
            {
                Console.WriteLine($"{Name} can't afford {product}");
                return;
            }
            Money -= product.Cost;
            this.products.Add(product);
            Console.WriteLine($"{Name} bought {product}");
        }

        public override string ToString()
        {
            string products = this.products.Any() ?
                string.Join(", ", this.products) :
                "Nothing bought";

            return $"{Name} - {products}";
        }

    }
}
