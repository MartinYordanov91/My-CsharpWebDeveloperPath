using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new();
        }

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount { get => this.Drinks.Count; }

        public void AddDrink(Drink drink)
        {
            if (this.ButtonCapacity > this.Drinks.Count)
            {
                this.Drinks.Add(drink);
            }
        }
        public bool RemoveDrink(string name)
        {
            if (this.Drinks.Any(n => n.Name == name))
            {
                Drink remulve = this.Drinks.First(n => n.Name == name);
                this.Drinks.Remove(remulve);
                return true;
            }
            return false;
        }
        public Drink GetLongest()
        {

            Drink bigVolume = this.Drinks.OrderByDescending(v => v.Volume).FirstOrDefault();
            return bigVolume;
        }
        public Drink GetCheapest()
        {

            Drink bigPrice = this.Drinks.OrderBy(v => v.Price).FirstOrDefault();
            return bigPrice;
        }
        public string BuyDrink(string name)
        {

            Drink bigspecific = this.Drinks.FirstOrDefault(v => v.Name == name);
            return bigspecific.ToString();
        }
        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine("Drinks available:");
            foreach (Drink drink in this.Drinks)
            {
                sb.AppendLine(drink.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
