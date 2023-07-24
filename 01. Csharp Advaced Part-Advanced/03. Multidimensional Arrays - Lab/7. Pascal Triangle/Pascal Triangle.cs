namespace _7._Pascal_Triangle
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int cols = 1;
            long[][] pascalMatrix = new long[size][];
            
            for (int row = 0; row < size; row++)
            {

                pascalMatrix[row] = new long[cols];
                pascalMatrix[row][0] = 1;
                pascalMatrix[row][cols - 1] = 1;

                for (int col = 1; col < cols - 1; col++)
                {
                    pascalMatrix[row][col] = pascalMatrix[row - 1][col] + pascalMatrix[row - 1][col - 1];
                }
                cols++;
            }

            foreach (var row in pascalMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}