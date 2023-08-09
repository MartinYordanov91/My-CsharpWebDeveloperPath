namespace ReverseAndExclude;
using System;
internal class ReverseAndExclude
{
    private static void Main()
    {
        int[] masive = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int divisible = int.Parse(Console.ReadLine());
        Func<int, bool> isValide = (num) => num % divisible == 0;
        masive = masive.Where(x => !isValide(x)).Reverse().ToArray();
        Console.WriteLine(string.Join(" " , masive));
    }
}
