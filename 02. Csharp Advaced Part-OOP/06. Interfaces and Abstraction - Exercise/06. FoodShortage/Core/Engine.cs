using FoodShortage.Models;
using FoodShortage.Core.Interface;
using FoodShortage.Models.Interface;

namespace FoodShortage.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            int countBuyers = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < countBuyers; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    IBuyer rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    buyers.Add(rebel);
                }
                else
                {
                    IBuyer citizen = new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    buyers.Add(citizen);
                }
            }

            string buyer = string.Empty;
            while ((buyer = Console.ReadLine())!= "End")
            {
                if(buyers.Any(x => x.Name == buyer))
                {
                    IBuyer curent = buyers.First(x => x.Name == buyer);
                    curent.BuyFood();
                }
            }
            int foods = buyers.Sum(x => x.Food);
            Console.WriteLine(foods);
        }
    }
}
