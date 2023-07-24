namespace _6._Jagged_Array_Modification
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

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "END")
            {
                string[] comandArg = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = comandArg[0];
                int row = int.Parse(comandArg[1]);
                int col = int.Parse(comandArg[2]);
                int value = int.Parse(comandArg[3]);
                if(operation == "Add")
                {
                    if(row >= 0 && col >=0 && matrix.Length > row && matrix[row].Length > col)
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (operation == "Subtract")
                {
                    if (row >= 0 && col >= 0 && matrix.Length > row && matrix[row].Length > col)
                    {
                        matrix[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
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