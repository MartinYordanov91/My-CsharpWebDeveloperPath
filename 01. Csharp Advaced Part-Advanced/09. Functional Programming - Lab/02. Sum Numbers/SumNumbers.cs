namespace SumNumbers;
using System;
internal class SumNumbers
{
    private static void Main()
    {
        int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();
        Console.WriteLine(numbers.Count());
        Console.WriteLine(numbers.Sum());
    }
}