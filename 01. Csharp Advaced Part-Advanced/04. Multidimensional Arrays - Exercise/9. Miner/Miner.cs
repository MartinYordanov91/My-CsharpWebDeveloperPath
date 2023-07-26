namespace _9._Miner
{
    using System;
    using System.Drawing;

    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] movements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] gameArena = FillingArena(size);
            MinningGamePlay(gameArena, movements);
        }
        public static void MinningGamePlay(char[,] gameArena, string[] movements)
        {
            int coalCount = 0, rowSP = 0, colSP = 0;
            GetIndexAndCount(gameArena, ref rowSP, ref colSP, ref coalCount);
            bool deat = false;

            foreach (var move in movements)
            {
                if (move == "up")
                {
                    if (PositiontValide(rowSP - 1, colSP, gameArena))
                    {
                        if (IsEnd(rowSP - 1, colSP, gameArena))
                        {
                            deat = true;
                            break;
                        }

                        if (CoalForColeckt(rowSP - 1, colSP, gameArena))
                        {
                            coalCount--;
                            if (coalCount == 0)
                            {
                                Win(rowSP - 1, colSP);
                                break;
                            }
                        }
                        gameArena[rowSP, colSP] = '*';
                        rowSP -= 1;
                        gameArena[rowSP, colSP] = 's';
                    }
                }
                else if (move == "down")
                {
                    if (PositiontValide(rowSP + 1, colSP, gameArena))
                    {
                        if (IsEnd(rowSP + 1, colSP, gameArena))
                        {
                            deat = true;
                            break;
                        }

                        if (CoalForColeckt(rowSP + 1, colSP, gameArena))
                        {
                            coalCount--;
                            if (coalCount == 0)
                            {
                                Win(rowSP + 1, colSP);
                                break;
                            }
                        }
                        gameArena[rowSP, colSP] = '*';
                        rowSP += 1;
                        gameArena[rowSP, colSP] = 's';
                    }
                }
                else if (move == "right")
                {
                    if (PositiontValide(rowSP, colSP + 1, gameArena))
                    {
                        if (IsEnd(rowSP, colSP + 1, gameArena))
                        {
                            deat = true;
                            break;
                        }

                        if (CoalForColeckt(rowSP, colSP + 1, gameArena))
                        {
                            coalCount--;
                            if (coalCount == 0)
                            {
                                Win(rowSP, colSP + 1);
                                break;
                            }
                        }
                        gameArena[rowSP, colSP] = '*';
                        colSP += 1;
                        gameArena[rowSP, colSP] = 's';
                    }
                }
                else if (move == "left")
                {
                    if (PositiontValide(rowSP, colSP - 1, gameArena))
                    {
                        if (IsEnd(rowSP, colSP - 1, gameArena))
                        {
                            deat = true;
                            break;
                        }


                        if (CoalForColeckt(rowSP, colSP - 1, gameArena))
                        {
                            coalCount--;
                            if (coalCount == 0)
                            {
                                Win(rowSP, colSP - 1);
                                break;
                            }
                        }
                        gameArena[rowSP, colSP] = '*';
                        colSP -= 1;
                        gameArena[rowSP, colSP] = 's';
                    }
                }

            }
            if (!deat && coalCount > 0)
            {// приключили са ми ходовете
                Console.WriteLine($"{coalCount} coals left. ({rowSP}, {colSP})");
            }
        }
        public static void Win(int rol, int col)
        {// събрал съм всички налични суровени
            Console.WriteLine($"You collected all coals! ({rol}, {col})");
        }
        public static bool IsEnd(int row, int col, char[,] gameArena)
        { // проверка дли му прекратяват маршрута
            if (gameArena[row, col] == 'e')
            {
                Console.WriteLine($"Game over! ({row}, {col})");
                return true;
            }
            return false;
        }
        public static bool CoalForColeckt(int row, int col, char[,] gameArena)
        { // проверка дали съм срещнал суровина
            if (gameArena[row, col] == 'c')
            {
                return true;
            }

            return false;
        }
        public static bool PositiontValide(int row, int col, char[,] gameArena)
        {//проверка дали позицията е в матрицата
            if (row >= 0 == false ||
                col >= 0 == false ||
                row < gameArena.GetLength(0) == false ||
                col < gameArena.GetLength(1) == false)
            {
                return false;
            }
            return true;
        }
        public static void GetIndexAndCount(char[,] gameArena, ref int rowSP, ref int colSP, ref int coalCount)
        {// намирам колко суровина има и на коя позиция е минйора
            for (int row = 0; row < gameArena.GetLength(0); row++)
            {
                for (int col = 0; col < gameArena.GetLength(1); col++)
                {
                    if (gameArena[row, col] == 's')
                    {
                        rowSP = row;
                        colSP = col;
                    }
                    else if (gameArena[row, col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }


        }
        public static char[,] FillingArena(int size)
        {// попълвам матрицата
            char[,] arena = new char[size, size];

            for (int row = 0; row < arena.GetLength(0); row++)
            {
                char[] fildComponents = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < arena.GetLength(1); col++)
                {
                    arena[row, col] = fildComponents[col];
                }
            }
            return arena;
        }
    }
}
