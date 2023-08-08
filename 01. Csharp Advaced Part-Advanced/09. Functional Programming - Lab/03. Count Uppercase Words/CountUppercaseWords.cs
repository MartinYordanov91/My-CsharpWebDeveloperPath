namespace CountUppercaseWords;
using System;
using static System.Net.Mime.MediaTypeNames;

internal class CountUppercaseWords
{
    private static void Main()
    {
        string[] words = Console.ReadLine()
            .Split(" " , StringSplitOptions.RemoveEmptyEntries)
            .Where(word => char.IsUpper(word[0]))
            .ToArray();
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}