namespace MouseInTheKitchen
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowSize = matrixSize[0];
            int colSize = matrixSize[1];
            char[,] fild = new char[rowSize, colSize];
            int cheeseCount = default;
            int mausRow = default;
            int mausCol = default;

            for (int r = 0; r < fild.GetLength(0); r++)
            {
                string curentColInput = Console.ReadLine();
                for (int c = 0; c < fild.GetLength(1); c++)
                {
                    fild[r, c] = curentColInput[c];
                    if (curentColInput[c] == 'M')
                    {
                        mausRow = r;
                        mausCol = c;
                    }
                    if (curentColInput[c] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }
            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "danger")
            {
                int coppyRow = mausRow;
                int coppyCol = mausCol;

                if (comand == "up") { mausRow--; }
                if (comand == "down") { mausRow++; }
                if (comand == "right") { mausCol++; }
                if (comand == "left") { mausCol--; }

                if (mausRow < 0 || mausCol < 0 ||
                    mausRow >= fild.GetLength(0) ||
                    mausCol >= fild.GetLength(1))
                {
                    fild[coppyRow, coppyCol] = 'M';
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }
                if(fild[mausRow, mausCol] == '@')
                {
                    mausRow = coppyRow;
                    mausCol = coppyCol;
                    continue;
                }
                if (fild[mausRow, mausCol] == 'C')
                {
                    fild[coppyRow, coppyCol] = '*';
                    cheeseCount--;
                    if (cheeseCount <= 0)
                    {
                        fild[mausRow, mausCol] = 'M';
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }
                }
                if (fild[mausRow, mausCol] == 'T')
                {
                    fild[coppyRow, coppyCol] = '*';
                    fild[mausRow, mausCol] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    break;
                }
                fild[coppyRow, coppyCol] = '*';
            }

            if(comand == "danger")
            {
                Console.WriteLine("Mouse will come back later!");
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