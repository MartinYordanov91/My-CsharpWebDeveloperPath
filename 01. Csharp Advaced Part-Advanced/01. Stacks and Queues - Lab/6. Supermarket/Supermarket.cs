namespace _6._Supermarket
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new();

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "End")
            {
                if (comand == "Paid")
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else
                {
                    names.Enqueue(comand);
                }
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}