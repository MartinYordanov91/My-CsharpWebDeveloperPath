namespace _02._Basic_Queue_Operations
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
            int elementEnqueue = comandArg[0];
            int elementDequeue = comandArg[1];
            int elementLucingFor = comandArg[2];

            int[] elemetsForQueue = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbersQueue = new();

            for (int i = 0; i < elementEnqueue; i++)
            {
                numbersQueue.Enqueue(elemetsForQueue[i]);

            }

            for (int i = 0; i < elementDequeue; i++)
            {
                numbersQueue.Dequeue();
            }

            if (numbersQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbersQueue.Contains(elementLucingFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersQueue.Min());
            }
        }
    }
}