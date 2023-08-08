namespace AddVAT;
using System;
internal class AddVAT
{
    private static void Main()
    {
        double[] prices = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .Select(x => 1.2 * x)
            .ToArray();
        foreach (var pr in prices)
        {
            Console.WriteLine($"{pr:f2}");
        }
    }
}