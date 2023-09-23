using FoodShortage.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models
{
    internal class Citizens : IIdentification, IBirthdates, IBuyer
    {
        public Citizens(string name, int age, string id, string birthdates)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdates = birthdates;
            Food = default;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdates { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
