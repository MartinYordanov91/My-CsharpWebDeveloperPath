namespace _1._Reverse_a_String
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine()
                .ToCharArray();
            Stack<char> deversedString = new();

            foreach (char c in chars )
            {
                deversedString.Push(c);
            }

            while (deversedString.Count > 0)
            {
                Console.Write($"{deversedString.Pop()}");
            }
           
        }
    }
}