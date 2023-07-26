namespace _8._Bombs
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] mineField = FillingMatrix(size);
            Queue<string> bombCordinate = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            ExplodeBomb(mineField, bombCordinate);
            Result(mineField);
        }
        public static void Result(int[,] mineField)
        {// проброяване на оцелелите и сумиране на тяхната стойност
            int sum = 0, aLive = 0;

            for (int row = 0; row < mineField.GetLength(0); row++)
            {
                for (int col = 0; col < mineField.GetLength(1); col++)
                {
                    if (IsNotDeath(row, col, mineField)) { sum += mineField[row, col]; aLive++; }
                }
            }
             // печатаме резултатът
            Console.WriteLine($"Alive cells: {aLive}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < mineField.GetLength(0); row++)
            {
                for (int col = 0; col < mineField.GetLength(1); col++)
                {
                    Console.Write($"{mineField[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        public static void BombCheckList(int row, int col, int[,] mineField, int magnitute)
        { // нанасям щети на всички околни клетки ако са живи и ако са валидни
            if (IsNotDeath(row + 1, col - 1, mineField)) { mineField[row + 1, col - 1] -= magnitute; } // горе в ляво
            if (IsNotDeath(row + 1, col, mineField)) { mineField[row + 1, col] -= magnitute; } // горе
            if (IsNotDeath(row + 1, col + 1, mineField)) { mineField[row + 1, col + 1] -= magnitute; } //горе в дясно
            if (IsNotDeath(row, col - 1, mineField)) { mineField[row, col - 1] -= magnitute; } // ляво
            if (IsNotDeath(row, col + 1, mineField)) { mineField[row, col + 1] -= magnitute; } // дясно
            if (IsNotDeath(row - 1, col - 1, mineField)) { mineField[row - 1, col - 1] -= magnitute; } // доло в ляво
            if (IsNotDeath(row - 1, col, mineField)) { mineField[row - 1, col] -= magnitute; }//доло
            if (IsNotDeath(row - 1, col + 1, mineField)) { mineField[row - 1, col + 1] -= magnitute; } // доло в дясно
        }
        public static void ExplodeBomb(int[,] mineField, Queue<string> bombCordinate)
        { // започват експозиите
            while (bombCordinate.Any())
            {
                int[] curentCordinate = bombCordinate.Dequeue().Split(",", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray(); // кординати на бомбата
                int rows = curentCordinate[0];
                int cols = curentCordinate[1];
                int magnitute = 0;
                if (IsNotDeath(rows, cols, mineField))
                {// взимам силата на бомбата и занулявам позицията и ако е в матрицата
                    magnitute = mineField[rows, cols];
                    mineField[rows, cols] = 0;
                    BombCheckList(rows, cols, mineField, magnitute); // нанасям щети на всички околни клетки ако са живи
                }
            }
        }
        public static bool IsNotDeath(int rowIndex, int colIndex, int[,] mineField)
        {// проверка позицията дали е в матрицата 
            if (rowIndex >= 0 == false ||
                colIndex >= 0 == false ||
                rowIndex < mineField.GetLength(0) == false ||
                colIndex < mineField.GetLength(1) == false)
            {
                return false;
            } // проверка дали стойноста е по голяма от 0 
            if (mineField[rowIndex, colIndex] <= 0)
            {
                return false;
            }
            return true;
        }
        public static int[,] FillingMatrix(int size)
        { // създаваме и попълваме матрицата четейки от конзолата
            int[,] matrix = new int[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
    }
}