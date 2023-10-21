Аusing Microsoft.VisualBasic;

namespace FishingCompetition
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] fild = new char[n, n];
            int myRow = 0, myCol = 0;
            int countFish = 0;
            bool isLost = false;

            for (int row = 0; row < fild.GetLength(0); row++)
            {
                string cCol = Console.ReadLine();

                for (int col = 0; col < fild.GetLength(1); col++)
                {
                    fild[row, col] = cCol[col];

                    if (fild[row, col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }
                }
            }

            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "collect the nets")
            {
                int copyRow = myRow;
                int copyCol = myCol;

                switch (comand)
                {
                    case "up": myRow--; break;
                    case "down": myRow++; break;
                    case "left": myCol--; break;
                    case "right": myCol++; break;
                }

                if (myRow < 0 || myCol < 0 ||
                    myRow >= fild.GetLength(0) ||
                    myCol >= fild.GetLength(1))
                {
                    if (myRow < 0) { myRow = fild.GetLength(0) - 1; }
                    else if (myCol < 0) { myCol = fild.GetLength(1) - 1; }
                    else if (myRow >= fild.GetLength(0)) { myRow = 0; }
                    else if (myCol >= fild.GetLength(1)) { myCol = 0; }
                }

                if (fild[myRow, myCol] == 'W')
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{myRow},{myCol}]");
                    isLost = true;
                    break;
                }

                if (char.IsDigit(fild[myRow, myCol]))
                {
                    countFish += fild[myRow, myCol] - '0';
                }

                fild[myRow, myCol] = 'S';
                fild[copyRow, copyCol] = '-';
            }

            if (!isLost)
            {

                Console.WriteLine(countFish >= 20 ? "Success! You managed to reach the quota!" : $"You didn't catch enough fish and didn't reach the quota! You need {20 - countFish} tons of fish more.");

                if (countFish > 0) { Console.WriteLine($"Amount of fish caught: {countFish} tons."); }

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
}