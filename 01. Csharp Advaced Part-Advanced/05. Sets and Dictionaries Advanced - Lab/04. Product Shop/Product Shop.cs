namespace _04._Product_Shop
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new();
            string text = string.Empty;
            while ((text = Console.ReadLine()) != "Revision")
            {
                string[] information = text.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = information[0];
                string product = information[1];
                double price =double.Parse(information[2]);

                if (shops.ContainsKey(shop) == false)
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);
            }

            foreach (var shop in shops.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }

            }
        }
    }
}