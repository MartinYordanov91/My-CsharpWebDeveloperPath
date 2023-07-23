namespace _2._Sum_Matrix_Columns
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] parameters = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] mdArrays = new int[parameters[0], parameters[1]];
            long sum = 0;

            for (int rol = 0; rol < mdArrays.GetLength(0); rol++)
            {
                int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

                for (int col = 0; col < mdArrays.GetLength(1); col++)
                {
                    mdArrays[rol, col] = nums[col];

                }
            }

            for (int col = 0; col < mdArrays.GetLength(1); col++)
            {
                sum = 0;

                for (int rol = 0; rol < mdArrays.GetLength(0); rol++)
                {
                    sum += mdArrays[rol, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}