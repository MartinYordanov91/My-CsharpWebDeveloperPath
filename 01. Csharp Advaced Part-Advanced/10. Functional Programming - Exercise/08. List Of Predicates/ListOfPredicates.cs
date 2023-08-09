namespace ListOfPredicates;
using System;
internal class ListOfPredicates
{
    private static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int[] divisors = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int[] colection = Enumerable.Range(1, num).Where(x =>
        {

            foreach (int n in divisors)
            {
                if (x % n != 0) { return false; }
            }
            return true;
        })
            .ToArray();

        Console.WriteLine(string.Join(" ", colection));
    }
}