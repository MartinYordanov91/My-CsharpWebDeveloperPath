namespace _5._Print_Even_Numbers
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" " , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new();

            foreach (int i in nums)
            {
                if (i % 2 == 0)
                {
                    queue.Enqueue(i);
                }
            }
            Console.WriteLine(string.Join(", " , queue));
        }
    }
}