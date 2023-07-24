namespace _1._Diagonal_Difference
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int firstsum = 0, secondsum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] matrixNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixNumbers[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                firstsum += matrix[row, row];
            }

            for (int row = 0 ; row < matrix.GetLength(0); row++)
            {
                secondsum += matrix[row, matrix.GetLength(0) - row -1];
            }

            Console.WriteLine(Math.Abs(firstsum - secondsum));
            
        }
    }
}