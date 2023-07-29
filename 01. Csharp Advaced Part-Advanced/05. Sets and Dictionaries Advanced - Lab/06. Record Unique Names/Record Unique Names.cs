namespace _06._Record_Unique_Names
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            HashSet<string> hashSet= new();
            
            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                hashSet.Add(name);
            }

            foreach (var name in hashSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}