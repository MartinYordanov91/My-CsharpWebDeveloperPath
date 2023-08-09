namespace PredicateForNames;
using System;
internal class PredicateForNames
{
    private static void Main()
    {
        int maxLenght = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Where(x => x.Length <=maxLenght)
            .ToArray();
        Console.WriteLine(string.Join(Environment.NewLine , names));
    }
}