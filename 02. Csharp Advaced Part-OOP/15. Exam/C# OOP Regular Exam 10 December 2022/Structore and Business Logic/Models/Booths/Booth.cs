namespace ChristmasPastryShop.Models.Booths
{
    using System;
    using Contracts;
    using Cocktails.Contracts;
    using Delicacies.Contracts;
    using Repositories.Contracts;
    using ChristmasPastryShop.Repositories;
    using System.Text;

    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
        }

        public int BoothId
        {
            get => boothId;
            private set
            {
                boothId = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu
            => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu
            => cocktailMenu;

        public double CurrentBill
        {
            get => currentBill;
            private set
            {
                currentBill = value;
            }
        }

        public double Turnover
        {
            get => turnover;
            private set
            {
                turnover = value;
            }
        }

        public bool IsReserved
        {
            get => isReserved;
            private set
            {
                isReserved = value;
            }
        }

        public void ChangeStatus()
        {
            isReserved = isReserved ? false : true;
        }

        public void Charge()
        {
            turnover += currentBill;
            currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");

            foreach (var coctail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{coctail}");
            }
            sb.AppendLine($"-Delicacy menu:");

            foreach (var delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }

            return sb.ToString().Trim();
        }
    }
}
