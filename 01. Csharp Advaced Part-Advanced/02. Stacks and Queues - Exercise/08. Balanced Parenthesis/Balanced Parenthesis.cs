namespace _08._Balanced_Parenthesis
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isBalance = true;
            isBalance = PassageText(isBalance);
            PrintResult(isBalance);
        }
        public static void PrintResult (bool isBalance)
        {
            if (isBalance)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        public static bool PassageText(bool isBalance)
        {
            char[] charsInput = Console.ReadLine().ToCharArray();
            Stack<char> stackChars = new();

            foreach (char c in charsInput)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stackChars.Push(c);
                }
                else
                {
                    if (stackChars.Count == 0)
                    {
                        return false;
                    }
                    if ((stackChars.Peek() == '(' && c == ')') ||
                       (stackChars.Peek() == '[' && c == ']') ||
                      (stackChars.Peek() == '{' && c == '}'))
                    {
                        stackChars.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}