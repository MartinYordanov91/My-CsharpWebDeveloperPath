namespace _4._Symbol_in_Matrix
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int colRow = int.Parse(Console.ReadLine());
            char[,] matrix = new char[colRow, colRow];
            bool isFind = false;
            string end = string.Empty;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] characters = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = characters[col];
                }
            }

            char locingFor = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == locingFor)
                    {
                        isFind = true;
                        end = $"({row}, {col})";
                        break;
                    }
                }
                if (isFind) { break; }
            }

            if (isFind)
            {
                Console.WriteLine(end);
            }
            else
            {
                Console.WriteLine($"{locingFor} does not occur in the matrix");
            }
        }
    }
}