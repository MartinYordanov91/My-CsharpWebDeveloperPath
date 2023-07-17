namespace _3._Simple_Calculator
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> operationss = new();
            double result = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                operationss.Push(input[i]);
            }

            if (operationss.Count > 0)
            {
                result = double.Parse(operationss.Pop());
            }

            while (operationss.Count > 0)
            {
                string operationArg = operationss.Pop();
                double num = double.Parse(operationss.Pop()); ;
                if (operationArg == "-")
                {
                    result -= num;
                }
                else if (operationArg == "+")
                {
                    result += num;
                }
            }
            Console.WriteLine(result);
        }
    }
}