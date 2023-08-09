namespace AppliedArithmetics;
using System;
internal class AppliedArithmetics
{
    private static void Main()
    {
        int[] numberArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        string comand = string.Empty;

        while ((comand = Console.ReadLine()) != "end")
        {
            if (comand == "add")
            {
               numberArray= numberArray.Select(x => x += 1).ToArray();
            }
            else if (comand == "multiply")
            {
                numberArray= numberArray.Select(x => x *= 2).ToArray();
            }
            else if (comand == "subtract")
            {
                numberArray = numberArray.Select(x => x -= 1).ToArray();
            }
            else if(comand == "print")
            {
                Console.WriteLine(string.Join(" ", numberArray));
            }
        }
    }
}