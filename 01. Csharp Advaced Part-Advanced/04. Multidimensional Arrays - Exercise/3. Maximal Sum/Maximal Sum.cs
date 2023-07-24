namespace _3._Maximal_Sum
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int count = 0;

            int[,] matrix = new int[size.First(), size.Last()];
            int maxSum = 0;
            int rowIndex = 0, colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] matrixNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixNumbers[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = 0;
                    for (int subRow = 0; subRow < 3; subRow++)
                    {
                        for (int subCol = 0; subCol < 3; subCol++)
                        {
                            sum += matrix[row + subRow, col + subCol];

                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);

            for (int roweEnd = rowIndex; roweEnd < rowIndex + 3; roweEnd++)
            {
                for (int colEnd = colIndex; colEnd < colIndex + 3; colEnd++)
                {
                    Console.Write(matrix[roweEnd, colEnd] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}