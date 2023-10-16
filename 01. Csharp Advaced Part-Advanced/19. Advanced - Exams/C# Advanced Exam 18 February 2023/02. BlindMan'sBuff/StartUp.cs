namespace BlindMan_sBuff
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] matrixParameter = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            int matrixRows = matrixParameter[0];
            int matrixCols = matrixParameter[1];
            int[,] fild = new int[matrixRows, matrixCols];

            int playerRowPosition = 0;
            int playerColPosition = 0;

            int moolvesCount = 0;
            int oponentTuch = 0;

            for (int row = 0; row < fild.GetLength(0); row++)
            {
                char[] curentColSimbols = Console.ReadLine().Split(' ' , StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < fild.GetLength(1); col++)
                {
                    fild[row, col] = curentColSimbols[col];

                    if (fild[row, col] == 'B')
                    {
                        playerRowPosition = row;
                        playerColPosition = col;
                    }
                }
            }

            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "Finish" && oponentTuch != 3)
            {
                int copyRowPosition = playerRowPosition;
                int copyColPosition = playerColPosition;

                switch (comand)
                {
                    case "up":
                        playerRowPosition--;
                        break;
                    case "down":
                        playerRowPosition++;
                        break;
                    case "right":
                        playerColPosition++;
                        break;
                    case "left":
                        playerColPosition--;
                        break;

                }

                if(AreOutsideOrObstacles(playerRowPosition , playerColPosition , fild))
                {
                    playerRowPosition = copyRowPosition;
                    playerColPosition = copyColPosition;
                    continue;
                }

                fild[copyRowPosition, copyColPosition] = '-';
                moolvesCount++;

                if (fild[playerRowPosition,playerColPosition]== 'P')
                {
                    oponentTuch++;
                }

                fild[playerRowPosition, playerColPosition] = 'B';
            }

            Console.WriteLine($"Game over!{Environment.NewLine}Touched opponents: {oponentTuch} Moves made: {moolvesCount}");
        }

        public static bool AreOutsideOrObstacles(int row , int col , int[,] fild)
        {
            if(row < 0  || col < 0 ||
                row >= fild.GetLength(0)||
                col >= fild.GetLength(0))
            {
                return true;
            }

            if (fild[row,col] == 'O')
            {
                return true;
            }
            return false;
        }
    }
}