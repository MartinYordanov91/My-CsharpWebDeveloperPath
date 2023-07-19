namespace _01._Basic_Stack_Operations
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] comandArg = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int elementPush = comandArg[0];
            int elementPop = comandArg[1];
            int elementLucingFor = comandArg[2];

            int[] elemetsForStack = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbersStack = new();

            for (int i = 0; i < elementPush; i++)
            {
                numbersStack.Push(elemetsForStack[i]);

            }

            for (int i = 0; i < elementPop; i++)
            {
                numbersStack.Pop();
            }

            if (numbersStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbersStack.Contains(elementLucingFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersStack.Min());
            }
        }
    }
}