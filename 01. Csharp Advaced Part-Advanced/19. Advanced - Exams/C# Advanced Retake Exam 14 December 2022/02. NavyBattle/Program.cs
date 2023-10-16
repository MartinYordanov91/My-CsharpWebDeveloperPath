namespace NavyBattle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] fild = new char[size, size];

            int submarineRow = 0;
            int submarineCol = 0;
            int minesCount = 0;
            int cruisersCount = 0;

            for (int row = 0; row < fild.GetLength(0); row++)
            {
                string inputCol = Console.ReadLine();

                for (int col = 0; col < fild.GetLength(1); col++)
                {
                    fild[row, col] = inputCol[col];

                    if (fild[row, col] == 'S')
                    {
                        submarineRow = row;
                        submarineCol = col;
                    }
                }
            }

            while (true)
            {
                string comand = Console.ReadLine();
                int copyRow = submarineRow;
                int copyCol = submarineCol;

                switch (comand)
                {
                    case "down": submarineRow++; break;
                    case "up": submarineRow--; break;
                    case "left": submarineCol--; break;
                    case "right": submarineCol++; break;
                }

                if (fild[submarineRow, submarineCol] == 'C') { cruisersCount++; }
                if (fild[submarineRow, submarineCol] == '*') { minesCount++; }

                fild[submarineRow, submarineCol] = 'S';
                fild[copyRow, copyCol] = '-';

                if (minesCount == 3)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
                    break;
                }
                if (cruisersCount == 3)
                {
                    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                    break;
                }
            }

            for (int row = 0; row < fild.GetLength(0); row++)
            {
                for (int col = 0; col < fild.GetLength(1); col++)
                {
                    Console.Write(fild[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}