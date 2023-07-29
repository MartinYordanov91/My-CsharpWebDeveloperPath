namespace _05._Count_Symbols
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charcolection = new();
            string textInput = Console.ReadLine();
            foreach (var c in textInput)
            {
                if (charcolection.ContainsKey(c) == false)
                {
                    charcolection[c] = 0;
                }
                charcolection[c]++;
            }
            foreach (var c in charcolection)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}