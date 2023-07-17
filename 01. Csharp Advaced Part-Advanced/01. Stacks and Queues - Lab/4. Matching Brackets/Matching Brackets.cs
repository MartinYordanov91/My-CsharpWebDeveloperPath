namespace _4._Matching_Brackets
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            string chars = Console.ReadLine();
                
            Stack<int> ints = new();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '(')
                {
                    ints.Push(i);
                }
                else if (chars[i] == ')')
                {
                    int start = ints.Pop();
                    int end = i ;
                    
                    Console.WriteLine(chars.Substring(start , end - start +1));
                }
            }
        }
    }
}