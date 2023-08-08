namespace CountUppercaseWords;
using System;
using static System.Net.Mime.MediaTypeNames;

internal class CountUppercaseWords
{
    private static void Main()
    {
        Func<string, bool> isUperIndexZero = word => char.IsUpper(word[0]);

        string[] words = Console.ReadLine()
            .Split(" " , StringSplitOptions.RemoveEmptyEntries)
            .Where(isUperIndexZero)
            .ToArray();

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}