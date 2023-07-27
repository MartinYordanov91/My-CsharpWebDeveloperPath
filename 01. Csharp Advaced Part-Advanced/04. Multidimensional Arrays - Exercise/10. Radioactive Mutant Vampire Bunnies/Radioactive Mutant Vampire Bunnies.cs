namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    using System;
    using System.Data;
    using System.Xml;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            char[,] vampireField = new char[size[0], size[1]];
            int rowSP = 0, colSP = 0;

            for (int row = 0; row < vampireField.GetLength(0); row++)
            {
                string curentCol = Console.ReadLine();

                for (int col = 0; col < vampireField.GetLength(1); col++)
                {
                    vampireField[row, col] = curentCol[col];

                    if (vampireField[row, col] == 'P')
                    {
                        rowSP = row;
                        colSP = col;
                    }
                }
            }
            string comands = Console.ReadLine();
            bool isWin = false;
            bool isDeath = false;

            for (int comand = 0; comand < comands.Length; comand++)
            {
                switch (comands[comand])
                {
                    case 'U':
                        if (IsInTheField(rowSP -1, colSP, vampireField))
                        {
                            if (IsBunnyThear(rowSP - 1, colSP, vampireField))
                            {
                                isDeath = true;
                                rowSP -= 1;
                            }
                            else
                            {
                                vampireField[rowSP, colSP] = '.';
                                rowSP -= 1;
                                vampireField[rowSP, colSP] = 'P';
                            }
                        }
                        else { isWin = true; vampireField[rowSP, colSP] = '.'; }
                        break;
                    case 'L':

                        if (IsInTheField(rowSP, colSP - 1, vampireField))
                        {
                            if (IsBunnyThear(rowSP, colSP - 1, vampireField))
                            {
                                isDeath = true;
                                colSP -= 1; ;
                            }
                            else
                            {
                                vampireField[rowSP, colSP] = '.';
                                colSP -= 1; ;
                                vampireField[rowSP, colSP] = 'P';
                            }
                        }
                        else { isWin = true; vampireField[rowSP, colSP] = '.'; }
                        break;
                    case 'R':
                        if (IsInTheField(rowSP, colSP + 1, vampireField))
                        {
                            if (IsBunnyThear(rowSP, colSP + 1, vampireField))
                            {
                                isDeath = true;
                                colSP += 1; ;
                            }
                            else
                            {
                                vampireField[rowSP, colSP] = '.';
                                colSP += 1; ;
                                vampireField[rowSP, colSP] = 'P';
                            }
                        }
                        else { isWin = true; vampireField[rowSP, colSP] = '.'; }
                        break;
                    case 'D':
                        if (IsInTheField(rowSP + 1, colSP, vampireField))
                        {
                            if (IsBunnyThear(rowSP + 1, colSP, vampireField))
                            {
                                isDeath = true;
                                rowSP += 1;
                            }
                            else
                            {
                                vampireField[rowSP, colSP] = '.';
                                rowSP += 1;
                                vampireField[rowSP, colSP] = 'P';
                            }
                        }
                        else { isWin = true; vampireField[rowSP, colSP] = '.'; }
                        break;
                }
                Queue<int[]> bunny = new Queue<int[]>();
                for (int row = 0; row < vampireField.GetLength(0); row++)
                {
                    for (int col = 0; col < vampireField.GetLength(1); col++)
                    {
                        if (IsBunnyThear(row, col, vampireField))
                        {
                            int[] cordinate = new int[2] { row, col };
                            bunny.Enqueue(cordinate);
                        }
                    }
                }
                while (bunny.Any())
                {
                    int[] curentBunny = bunny.Dequeue();
                    int rowB = curentBunny[0];
                    int colB = curentBunny[1];
                    if (IsInTheField(rowB + 1, colB, vampireField))
                    {
                        if (IsPlayerThear(rowB + 1, colB, vampireField)) { isDeath = true; }
                        vampireField[rowB + 1, colB] = 'B';
                    }
                    if (IsInTheField(rowB - 1, colB, vampireField))
                    {
                        if (IsPlayerThear(rowB - 1, colB, vampireField)) { isDeath = true; }
                        vampireField[rowB - 1, colB] = 'B';
                    }
                    if (IsInTheField(rowB, colB + 1, vampireField))
                    {
                        if (IsPlayerThear(rowB, colB + 1, vampireField)) { isDeath = true; }
                        vampireField[rowB, colB + 1] = 'B';
                    }
                    if (IsInTheField(rowB, colB - 1, vampireField))
                    {
                        if (IsPlayerThear(rowB, colB - 1, vampireField)) { isDeath = true; }
                        vampireField[rowB, colB - 1] = 'B';
                    }

                }

                if (isWin || isDeath) { break; }
            }
            for (int row = 0; row < vampireField.GetLength(0); row++)
            {
                for (int col = 0; col < vampireField.GetLength(1); col++)
                {
                    Console.Write(vampireField[row, col]);
                }
                Console.WriteLine();
            }
            if (isWin)
            {
                Console.WriteLine($"won: {rowSP} {colSP}");
            }
            else
            {
                Console.WriteLine($"dead: {rowSP} {colSP}");
            }
        }
        public static bool IsPlayerThear(int rowIndex, int colIndex, char[,] vampireField)
        {
            if (vampireField[rowIndex, colIndex] == 'P') { return true; }
            return false;
        }
        public static bool IsBunnyThear(int rowIndex, int colIndex, char[,] vampireField)
        {
            if (vampireField[rowIndex, colIndex] == 'B') { return true; }
            return false;
        }
        public static bool IsInTheField(int rowIndex, int colIndex, char[,] vampireField)
        {
            if (rowIndex >= 0 == false || colIndex >= 0 == false || rowIndex < vampireField.GetLength(0) == false || colIndex < vampireField.GetLength(1) == false) { return false; }
            return true;
        }
    }
}