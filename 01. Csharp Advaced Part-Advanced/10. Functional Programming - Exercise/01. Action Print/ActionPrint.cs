namespace ActionPrint;
using System;
internal class ActionPrint
{
    private static void Main()
    {
        Action<string> print = masage => Console.WriteLine(masage);
        string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string name in names) { print(name); }
    }
}