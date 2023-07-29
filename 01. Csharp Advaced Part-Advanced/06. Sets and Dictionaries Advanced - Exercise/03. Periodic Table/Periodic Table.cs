namespace _03._Periodic_Table
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new();

            for (int i = 0; i < n; i++)
            {
                string[] curentElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in curentElements)
                {
                    elements.Add(element);
                }
            }

            foreach (var item in elements.OrderBy(x=>x))
            {
                Console.Write(item + " ");
            }
        }
    }
}