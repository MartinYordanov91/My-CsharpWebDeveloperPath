namespace _09._Simple_Text_Editor
{
    using System;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            int operationsSteps = int.Parse(Console.ReadLine());
            Stack<string> backup = new();
            backup.Push(string.Empty);

            for (int i = 0; i < operationsSteps; i++)
            {
                string[] comandArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (comandArg[0] == "1")
                {
                    backup.Push(backup.Peek() + comandArg[1]);
                }
                else if (comandArg[0] == "2")
                {
                    int lenghtRemulve = int.Parse(comandArg[1]);
                    string newOne = backup.Peek().Remove(backup.Peek().Length - lenghtRemulve);
                    backup.Push(newOne);
                }
                else if (comandArg[0] == "3")
                {
                    int item = int.Parse(comandArg[1]) -1;
                    Console.WriteLine(backup.Peek()[item]);
                }
                else if (comandArg[0] == "4")
                {
                    backup.Pop();
                } 
            }
        }
    }
}