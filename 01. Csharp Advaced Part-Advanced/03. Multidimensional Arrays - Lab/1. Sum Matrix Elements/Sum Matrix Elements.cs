namespace _1._Sum_Matrix_Elements
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split(", " , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] mdArrays = new int[parameters[0], parameters[1]];
            long sum = 0;

            for (int i = 0; i < mdArrays.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

                for (int j = 0; j < mdArrays.GetLength(1); j++)
                {
                    mdArrays[i, j] = nums[j];
                    sum += nums[j];
                }
            }

            Console.WriteLine($"{mdArrays.GetLength(0)}");
            Console.WriteLine($"{mdArrays.GetLength(1)}");
            Console.WriteLine($"{sum}");

            
        }
    }
}