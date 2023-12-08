namespace ChristmasPastryShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Cocktails;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using Contracts;
    public class Controller : IController
    {
        BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int curentId = booths.Models.Count + 1;
            Booth booth = new Booth(curentId, capacity);
            booths.AddModel(booth);
            return $"Added booth number {curentId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail = null;

            if (cocktailTypeName == "MulledWine")
            {
                if (size != "Small" && size != "Middle" && size != "Large")
                {
                    return $"{size} is not recognized as valid cocktail size!";
                }

                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == "Hibernation")
            {
                if (size != "Small" && size != "Middle" && size != "Large")
                {
                    return $"{size} is not recognized as valid cocktail size!";
                }

                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            Booth booth = booths.Models.First(x => x.BoothId == boothId) as Booth;
            if (booth.CocktailMenu.Models.Contains(cocktail))
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            booth.CocktailMenu.AddModel(cocktail);
            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }


        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;

            if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            if (booths.Models.First(x => x.BoothId == boothId).DelicacyMenu.Models.Any(x => x.Name == delicacyName))
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            booths.Models.First(x => x.BoothId == boothId).DelicacyMenu.AddModel(delicacy);
            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId) as Booth;
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId) as Booth;
            double curentbil = Math.Round(booth.CurrentBill, 2);
            booth.Charge();
            booth.ChangeStatus();

            return $"Bill {curentbil:f2} lv{Environment.NewLine}Booth {boothId} is now available!";
        }

        public string ReserveBooth(int countOfPeople)
        {
            Booth booth = booths.Models
                .Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .FirstOrDefault()
                as Booth;

            if (booth == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }

            booth.ChangeStatus();
            return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";

        }

        public string TryOrder(int boothId, string order)
        {
            string[] comand = order
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = comand[0];
            string itemName = comand[1];
            int ItemPiece = int.Parse(comand[2]);

            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId) as Booth;

            if (itemTypeName != "Stolen" &&
                itemTypeName != "Gingerbread" &&
                itemTypeName != "MulledWine" &&
                itemTypeName != "Hibernation")
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if (booth.CocktailMenu.Models.Any(x => x.Name == itemName) == false &&
                booth.DelicacyMenu.Models.Any(x => x.Name == itemName) == false)
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }

            if (comand.Count() == 4)
            {
                string size = comand[3];

                var coctail = booth.CocktailMenu.Models.FirstOrDefault(x =>
                x.GetType().Name == itemTypeName &&
                x.Name == itemName &&
                x.Size == size) as Cocktail;

                if (coctail == null)
                {
                    return $"There is no {size} {itemName} available!";
                }

                double price = booth.CocktailMenu.Models.First(x => x.GetType().Name == itemTypeName &&
                    x.Name == itemName &&
                    x.Size == size).Price;

                booth.UpdateCurrentBill(price * ItemPiece);
                return $"Booth {boothId} ordered {ItemPiece} {itemName}!";
            }

            if(booth.DelicacyMenu.Models.FirstOrDefault(x=>x.GetType().Name == itemTypeName && x.Name==itemName) == null)
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }

            double delicacyPrice = booth.DelicacyMenu.Models.First(x => x.GetType().Name == itemTypeName &&
            x.Name == itemName).Price;

            booth.UpdateCurrentBill(delicacyPrice * ItemPiece);
            return $"Booth {boothId} ordered {ItemPiece} {itemName}!";
        }
    }
}
