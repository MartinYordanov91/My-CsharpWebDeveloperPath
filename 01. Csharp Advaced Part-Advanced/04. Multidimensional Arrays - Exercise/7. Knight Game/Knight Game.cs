namespace _7._Knight_Game
{
    using System;
    using System.Numerics;

    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine()); //взимам размери
            char[,] chessBord = FillingBord(size); // попълвам си матрицата
            int remulvedHorse = PlayGame(chessBord); //търся кой кон да махна
            Console.WriteLine(remulvedHorse);
        }
        public static int PlayGame(char[,] chessBord)
        {
            int delite = 0;

            for (int levelAgresive = 8; levelAgresive > 0; levelAgresive--) // максималнно много мишени към минимално
            {
                for (int row = 0; row < chessBord.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBord.GetLength(1); col++)
                    {
                        if (chessBord[row, col] == 'K') //имали конче 
                        {
                            int horseLevel = HorseLevelAgresive(row, col, chessBord); // колко мишени може да удари
                            if (levelAgresive == horseLevel) // ако броят на мишените е равен на текущият който преглеждаме
                            {
                                chessBord[row, col] = '0'; //трием
                                delite++; // и проброяваме
                            }
                        }
                    }
                }
            }

            return delite;
        }
        public static int HorseLevelAgresive(int rowIndex, int colIndex, char[,] chessBord)
        { //всички възможни движения на коня
            int level = 0;
            if (ArHorseThear(rowIndex + 2, colIndex + 1, chessBord)) { level++; } // най горе в дясно
            if (ArHorseThear(rowIndex + 2, colIndex - 1, chessBord)) { level++; } // най горе в ляво
            if (ArHorseThear(rowIndex - 2, colIndex + 1, chessBord)) { level++; } // най доло в дясно
            if (ArHorseThear(rowIndex - 2, colIndex - 1, chessBord)) { level++; } // най доло в ляво
            if (ArHorseThear(rowIndex + 1, colIndex + 2, chessBord)) { level++; } // горе в най дясно
            if (ArHorseThear(rowIndex - 1, colIndex + 2, chessBord)) { level++; } // доло в най дясно
            if (ArHorseThear(rowIndex + 1, colIndex - 2, chessBord)) { level++; } // горе в най ляво
            if (ArHorseThear(rowIndex - 1, colIndex - 2, chessBord)) { level++; } // доло в най ляво
            return level;
        }
        public static bool ArHorseThear(int rowIndex, int colIndex, char[,] chessBord)
        {
            if (rowIndex >= 0 == false ||
                colIndex >= 0 == false ||
                rowIndex < chessBord.GetLength(0) == false ||
                colIndex < chessBord.GetLength(1) == false)
            { // вътре в полето ли съм
                return false;
            }
            if (chessBord[rowIndex, colIndex] != 'K')
            { // има няма конче ?
                return false;
            }

            return true;
        }
        public static char[,] FillingBord(int size)
        { // четене и попълване на матрицата
            char[,] matrix = new char[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string chars = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            return matrix;
        }
    }
}