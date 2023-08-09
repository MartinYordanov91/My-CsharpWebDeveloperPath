namespace CustomMinFunction;
using System;
internal class CustomMinFunction
{
    private static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        Console.WriteLine(numbers.Min());
    }
}