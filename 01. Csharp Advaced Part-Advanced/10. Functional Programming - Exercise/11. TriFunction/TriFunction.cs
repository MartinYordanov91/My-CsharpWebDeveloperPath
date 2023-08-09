namespace TriFunction;
using System;
internal class TriFunction
{
    private static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string name = names.First(x => x.Sum(n => (int)n) >= num);

        Console.WriteLine(name);
    }
}