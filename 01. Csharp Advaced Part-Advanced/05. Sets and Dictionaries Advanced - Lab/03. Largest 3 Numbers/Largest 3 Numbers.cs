namespace _03._Largest_3_Numbers
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integersSorted = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int count = 0;
            foreach (int i in integersSorted.OrderByDescending(c => c))
            {
                count++;
                if (count == 4) { break; }
                Console.Write(i + " ");
            }
        }
    }
}