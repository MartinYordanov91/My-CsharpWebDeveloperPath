namespace _02._Sets_of_Elements
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setsLenght = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            HashSet<int> first = new();
            HashSet<int> second = new();

            for (int i = 0; i < setsLenght.Sum(); i++)
            {
                int curentNumber = int.Parse(Console.ReadLine());

                if (i < setsLenght[0])
                {
                    first.Add(curentNumber);
                }
                else
                {
                    second.Add(curentNumber);
                }

            }

            foreach (int set in first)
            {
                if (second.Contains(set))
                {
                    Console.Write(set + " ");
                }
            }
        }
    }
}