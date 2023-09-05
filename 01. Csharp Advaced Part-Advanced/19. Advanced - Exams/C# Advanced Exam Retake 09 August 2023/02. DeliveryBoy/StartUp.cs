namespace DeliveryBoy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int matrixRow = matrixSizes[0];
            int matrixCol = matrixSizes[1];
            int deliveryBoyStartRow = default;
            int deliveryBoyStartCol = default;
            bool isPizzaTaken = false;
            char[,] fild = new char[matrixRow, matrixCol];

            for (int row = 0; row < fild.GetLength(0); row++)
            {
                string curentRow = Console.ReadLine();

                for (int col = 0; col < fild.GetLength(1); col++)
                {
                    fild[row, col] = curentRow[col];
                    if (curentRow[col] == 'B')
                    {
                        deliveryBoyStartRow = row;
                        deliveryBoyStartCol = col;
                    }
                }
            }
            int nexRow = deliveryBoyStartRow;
            int nexCol = deliveryBoyStartCol;

            while (true)
            {
                int copyRow = nexRow;
                int copyCol = nexCol;
                string comand = Console.ReadLine();

                if (comand == "up") { nexRow--; }

                else if (comand == "down") { nexRow++; }

                else if (comand == "right") { nexCol++; }

                else if (comand == "left") { nexCol--; }



                if (nexRow < 0 || nexCol < 0 ||
                    fild.GetLength(0) <= nexRow ||
                    fild.GetLength(1) <= nexCol)
                {
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    fild[deliveryBoyStartRow, deliveryBoyStartCol] = ' ';
                    break;
                }
                if (fild[nexRow, nexCol] == '*')
                {
                    nexRow = copyRow;
                    nexCol = copyCol;
                    continue;
                }
                if (fild[nexRow, nexCol] == 'P')
                {
                    fild[nexRow, nexCol] = 'R';
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                    continue;
                }
                if (fild[nexRow, nexCol] == 'A')
                {
                    fild[nexRow, nexCol] = 'P';
                    fild[deliveryBoyStartRow, deliveryBoyStartCol] = 'B';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
                fild[nexRow, nexCol] = '.';
            }

            for (int row = 0; row < fild.GetLength(0); row++)
            {
                for (int col = 0; col < fild.GetLength(1); col++)
                {
                    Console.Write(fild[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}