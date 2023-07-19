namespace _04._Fast_Food
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] queriesEmployers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> emloyers = new(queriesEmployers);

            Console.WriteLine(emloyers.Max());

            while (emloyers.Count > 0)
            {
                if (emloyers.Peek() <= foodQuantity)
                {
                    foodQuantity -= emloyers.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" " , emloyers)}");
                    break;
                }
            }
            if(emloyers.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}