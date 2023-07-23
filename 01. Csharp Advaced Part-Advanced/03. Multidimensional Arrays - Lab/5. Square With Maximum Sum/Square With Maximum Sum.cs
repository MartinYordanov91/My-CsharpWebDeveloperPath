namespace _5._Square_With_Maximum_Sum
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[,] matrix = new int[rowCol[0], rowCol[1]];
            int maxSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] integers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = integers[col];
                }
            }

            int r = 0, c = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        r = row;
                        c = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[r, c]} {matrix[r, c + 1]}");
            Console.WriteLine($"{matrix[r + 1, c]} {matrix[r + 1, c + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}