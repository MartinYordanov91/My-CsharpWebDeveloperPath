namespace _06._Wardrobe
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrone = new();
            for (int i = 0; i < n; i++)
            {
                string[] colors = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = colors[0];
                string[] cloting = colors[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (wardrone.ContainsKey(color) == false)
                {
                    wardrone[color] = new Dictionary<string, int>();
                }

                foreach (var clot in cloting)
                {
                    if (wardrone[color].ContainsKey(clot) == false)
                    {
                        wardrone[color][clot] = 0;
                    }
                    wardrone[color][clot]++;
                }
            }

            string[] lockingFor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorLockin = lockingFor[0];
            string clotsLocking = lockingFor[1];

            foreach (var color in wardrone)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clot in color.Value)
                {
                    Console.WriteLine(color.Key == colorLockin && clot.Key == clotsLocking
                        ? $"* {clot.Key} - {clot.Value} (found!)"
                        : $"* {clot.Key} - {clot.Value} ");
                }
            }
        }
    }
}