namespace TheSquirrel
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int matrixRowCol = int.Parse(Console.ReadLine());
            string[] molves = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            char[,] fild = new char[matrixRowCol, matrixRowCol];
            int squirrelRow = default;
            int squirrelCol = default;
            int hazelnutsCount = default;

            for (int r = 0; r < fild.GetLength(0); r++)
            {
                string curentCol = Console.ReadLine();
                for (int c = 0; c < fild.GetLength(1); c++)
                {
                    fild[r, c] = curentCol[c];
                    if (fild[r, c] == 's')
                    {
                        squirrelRow = r;
                        squirrelCol = c;
                    }
                }
            }

            for (int comand = 0; comand < molves.Length; comand++)
            {
                int copyRow = squirrelRow;
                int copyCol = squirrelCol;

                if (molves[comand] == "left") { squirrelCol--; }
                else if (molves[comand] == "right") { squirrelCol++; }
                else if (molves[comand] == "down") { squirrelRow++; }
                else if (molves[comand] == "up") { squirrelRow--; }

                if (squirrelRow < 0 || squirrelCol < 0 ||
                    squirrelRow >= fild.GetLength(0) ||
                    squirrelCol >= fild.GetLength(1))
                {
                    fild[copyRow, copyCol] = '*';
                    Console.WriteLine("The squirrel is out of the field.");
                    break;
                }

                if (fild[squirrelRow, squirrelCol] == 't')
                {
                    fild[copyRow, copyCol] = '*';
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    break;
                }

                if (fild[squirrelRow, squirrelCol] == 'h')
                {
                    hazelnutsCount++;
                    fild[copyRow, copyCol] = '*';
                    fild[squirrelRow, squirrelCol] = 's';
                    if (hazelnutsCount == 3)
                    {
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        break;
                    }
                    continue;
                }
                if (comand == molves.Length - 1)
                {
                    Console.WriteLine("There are more hazelnuts to collect.");
                }

                fild[copyRow, copyCol] = '*';
                fild[squirrelRow, squirrelCol] = 's';
            }
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
        }
    }
}