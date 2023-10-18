using System;

namespace WallDestroyer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] fild = new char[size, size];

            int vankoRow = 0, vankoCol = 0;
            int rodCount = 0;
            int holeCount = 1;
            bool isElektrocute = false;

            for (int row = 0; row < fild.GetLength(0); row++)
            {
                string curentCol = Console.ReadLine();

                for (int col = 0; col < fild.GetLength(1); col++)
                {
                    fild[row, col] = curentCol[col];

                    if (fild[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;

                    }
                }
            }

            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "End")
            {
                int copyRow = vankoRow;
                int copyCol = vankoCol;

                switch (comand)
                {
                    case "up": vankoRow--; break;
                    case "down": vankoRow++; break;
                    case "left": vankoCol--; break;
                    case "right": vankoCol++; break;
                }

                if (vankoRow < 0 || vankoCol < 0
                    || vankoRow >= fild.GetLength(0)
                    || vankoCol >= fild.GetLength(1))
                {
                    vankoRow = copyRow;
                    vankoCol = copyCol;
                    continue;
                }

                if (fild[vankoRow,vankoCol] == 'R')
                {
                    rodCount++;
                    vankoRow = copyRow;
                    vankoCol = copyCol;
                    Console.WriteLine("Vanko hit a rod!");
                    continue;
                }
                
                fild[copyRow, copyCol] = '*';

                if(fild[vankoRow, vankoCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    continue;
                }

                holeCount++;

                if(fild[vankoRow, vankoCol] == 'C')
                {
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");
                    fild[vankoRow, vankoCol] = 'E';
                    isElektrocute = true;
                    break;
                }
                fild[vankoRow, vankoCol] = 'V';
            }

            if (fild[vankoRow, vankoCol] != 'E') { fild[vankoRow, vankoCol] = 'V'; }

            if (!isElektrocute)
            {
                Console.WriteLine($"Vanko managed to make {holeCount} hole(s) and he hit only {rodCount} rod(s).");
            }

            for (int r = 0; r < fild.GetLength(0); r++)
            {
                for (int c = 0; c < fild.GetLength(1); c++)
                {
                    Console.Write(fild[r,c]);
                }
                Console.WriteLine();
            }
        }

    }
}
