namespace _2._Squares_in_Matrix
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int count = 0;
            char[,] charakters = new char[size.First(), size.Last()];

            for (int row = 0; row < charakters.GetLength(0); row++)
            {
                char[] charInput = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < charakters.GetLength(1); col++)
                {
                    charakters[row, col] = charInput[col];
                }
            }

            for (int row = 0; row < charakters.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < charakters.GetLength(1) - 1; col++)
                {
                    if (charakters[row, col] == charakters[row , col+1] &&
                        charakters[row, col] == charakters[row +1, col]&&
                        charakters[row, col] == charakters[row +1, col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}