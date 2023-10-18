using System;

namespace HelpAMole
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] fild = new char[size, size];

            int point = 0;
            int moliRow = 0, moliCol = 0;

            for (int row = 0; row < fild.GetLength(0); row++)
            {
                string colinput = Console.ReadLine();

                for (int col = 0; col < fild.GetLength(1); col++)
                {
                    fild[row, col] = colinput[col];

                    if (fild[row, col] == 'M')
                    {
                        moliRow = row;
                        moliCol = col;
                    }
                }
            }

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "End" && point < 25)
            {
                int copyRow = moliRow;
                int copyCol = moliCol;

                switch (comand)
                {
                    case "up": moliRow--; break;
                    case "down": moliRow++; break;
                    case "right": moliCol++; break;
                    case "left": moliCol--; break;
                }

                if (IsMoliTrayToGoOutsaid(moliRow, moliCol, fild))
                {
                    moliRow = copyRow;
                    moliCol = copyCol;
                    continue;
                }

                if (char.IsDigit(fild[moliRow, moliCol]))
                {
                    point += (int)fild[moliRow, moliCol] - '0';
                }

                if (fild[moliRow, moliCol] == 'S')
                {
                    point -= 3;
                    fild[moliRow, moliCol] = '-';

                    for (int r = 0; r < fild.GetLength(0); r++)
                    {
                        for (int c = 0; c < fild.GetLength(1); c++)
                        {
                            if (fild[r, c] == 'S')
                            {
                                moliRow = r;
                                moliCol = c;
                            }
                        }
                    }
                }

                fild[copyRow, copyCol] = '-';
                fild[moliRow, moliCol] = 'M';
            }

            Console.WriteLine(point >= 25 ?
                "Yay! The Mole survived another game!" :
                "Too bad! The Mole lost this battle!");

            Console.WriteLine(point >= 25 ?
                $"The Mole managed to survive with a total of {point} points." :
                $"The Mole lost the game with a total of {point} points.");

            for (int r = 0; r < fild.GetLength(0); r++)
            {
                for (int c = 0; c < fild.GetLength(1); c++)
                {
                    Console.Write(fild[r, c]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsMoliTrayToGoOutsaid(int row, int col, char[,] fild)
        {
            if (row < 0 || col < 0 ||
               fild.GetLength(0) <= row ||
               fild.GetLength(1) <= col)
            {
                Console.WriteLine("Don't try to escape the playing field!");
                return true;
            }
            return false;
        }
    }
}
