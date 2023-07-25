namespace _5._Snake_Moves
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = sizeMatrix[0];
            int cols = sizeMatrix[1];
            char[,] matrix = new char[rows, cols];
            string snakeElements = Console.ReadLine();
            int curentChar = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if(curentChar == snakeElements.Length)
                        {
                            curentChar = 0;
                        }

                        matrix[row,col] = snakeElements[curentChar];
                        curentChar++;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (curentChar == snakeElements.Length)
                        {
                            curentChar = 0;
                        }

                        matrix[row, col] = snakeElements[curentChar];
                        curentChar++;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

        }
    }
}