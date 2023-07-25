namespace _4._Matrix_Shuffling
{
    using System;
    using System.Numerics;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string[,] matrix = new string[sizeMatrix[0], sizeMatrix[1]];

            FillMatrix(matrix);
            ValidateOperation(matrix);
        }
        public static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] argomantsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = argomantsInput[col];
                }
            }

        }
        public static void ValidateOperation(string[,] matrix)
        {
            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "END")
            {
                string[] comandArg = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = comandArg[0];
                bool isValide = false;

                Regex digits = new(@"\bswap[ ]+\d+[ ]+\d+[ ]+\d+[ ]+\d+\b");
                Match validCommand = digits.Match(comand);
                if (!validCommand.Success)
                {

                    Console.WriteLine("Invalid input!");
                    continue;
                }

                isValide = IsValidCordinate(comand, matrix);

                if (isValide)
                {
                    SwapPiece(comand, matrix);
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
        }
        public static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void SwapPiece(string comand, string[,] matrix)
        {
            string[] comandArg = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int row1 = int.Parse(comandArg[1]);
            int col1 = int.Parse(comandArg[2]);
            int row2 = int.Parse(comandArg[3]);
            int col2 = int.Parse(comandArg[4]);

            string first = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = first;

        }
        public static bool IsValidCordinate(string comand, string[,] matrix)
        {
            string[] comandArg = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int row1 = int.Parse(comandArg[1]);
            int col1 = int.Parse(comandArg[2]);
            int row2 = int.Parse(comandArg[3]);
            int col2 = int.Parse(comandArg[4]);

            if (row1 >= 0 && col1 >= 0 && row2 >= 0 && col2 >= 0 &&
                row1 < matrix.GetLength(0) && col1 < matrix.GetLength(1) &&
                 row2 < matrix.GetLength(0) && col2 < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}