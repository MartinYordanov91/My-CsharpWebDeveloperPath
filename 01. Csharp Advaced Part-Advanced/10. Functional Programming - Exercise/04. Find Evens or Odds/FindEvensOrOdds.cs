namespace FindEvensOrOdds;
using System;
internal class FindEvensOrOdds
{
    private static void Main()
    {
        Predicate<int> isEvens = n => n % 2 == 0;
        int[] range = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        string comand = Console.ReadLine();

        for (int number = range[0]; number <= range[1]; number++)
        {
            if(comand== "odd")
            {
                if (!isEvens(number)) { Console.Write(number + " "); }
            }
            else
            {
                if (isEvens(number)) { Console.Write(number + " "); }
            }
        }
    }
}