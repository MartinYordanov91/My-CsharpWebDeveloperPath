namespace SortEvenNumber;

using System;
internal class SortEvenNumber
{
    private static void Main()
    {
        int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(x => x % 2 == 0)
            .OrderBy(x => x)
            .ToArray();

        Console.WriteLine(string.Join(", " , numbers));
        //4, 2, 1, 3, 5, 7, 1, 4, 2, 12

    }
}
