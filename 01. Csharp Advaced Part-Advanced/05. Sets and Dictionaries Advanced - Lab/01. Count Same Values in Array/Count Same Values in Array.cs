namespace _01._Count_Same_Values_in_Array
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int> colektions = new();
            foreach (var value in values)
            {
                if (colektions.ContainsKey(value) == false)
                {
                    colektions[value] = 0;
                }
                colektions[value]++;
            }

            foreach (var item in colektions)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}