namespace _6._Jagged_Array_Manipulator
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[int.Parse(Console.ReadLine())][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] curentCol = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                matrix[row] = new int[curentCol.Length];

                for (int col = 0; col < curentCol.Length; col++)
                {
                    matrix[row][col] = curentCol[col];
                }
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;

                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {

                        matrix[row + 1][col] /= 2;
                    }

                }

            }

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "End")
            {
                string[] comandArg = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = comandArg[0];
                int rowElement = int.Parse(comandArg[1]);
                int colElements = int.Parse(comandArg[2]);
                int value = int.Parse(comandArg[3]);

                if (rowElement >= 0 &&
                    colElements >= 0 &&
                    matrix.Length > rowElement &&
                    matrix[rowElement].Length > colElements)
                {
                    if (operation == "Add")
                    {
                        matrix[rowElement][colElements] += value;
                    }
                    else if (operation == "Subtract")
                    {
                        matrix[rowElement][colElements] -= value;
                    }
                }
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}