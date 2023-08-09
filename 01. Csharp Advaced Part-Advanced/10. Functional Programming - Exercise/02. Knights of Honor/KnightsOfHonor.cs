namespace KnightsOfHonor;
using System;
internal class KnightsOfHonor
{
    private static void Main()
    {
        Action<string> print = masage => Console.WriteLine($"Sir {masage}");
        string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string name in names) { print(name); }
        
    }
}