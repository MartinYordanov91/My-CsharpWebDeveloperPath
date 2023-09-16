using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private string flourType;
        private string bakingType;
        private double weight;

        public Dough(string flourType, string bakingType, double weight)
        {
            FlourType = flourType;
            BakingType = bakingType;
            Weight = weight;
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }
        private string BakingType
        {
            set
            {
                if (value.ToLower() != "crispy" &&
                    value.ToLower() != "chewy" &&
                    value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingType = value;
            }
        }
        private double Weight
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double GetCalories
        {
            get
            {
                double calories = 2;

                if (flourType.ToLower() == "white") { calories *= White; }
                else if (flourType.ToLower() == "wholegrain") { calories *= Wholegrain; }

                if (bakingType.ToLower() == "crispy") { calories *= Crispy; }
                else if (bakingType.ToLower() == "chewy") { calories *= Chewy; }
                else if (bakingType.ToLower() == "homemade") { calories *= Homemade; }

                return calories;
            }
        }

        public double Calories() => weight * this.GetCalories;

    }
}
