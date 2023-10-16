namespace ClimbThePeaks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int row = 0;
            int col = 0;

            string[,] Peacs = new string[,]
            {
             {"80 ","Vihren" },
             {"90 ","Kutelo"},
             {"100","Banski Suhodol"},
             {"60 ","Polezhan"},
             {"70 ","Kamenitza" }
            };

            List<string> PeacsList = new();

            Stack<int> food = new();
            foreach (var item in Console.ReadLine().Split(", ").Select(int.Parse).ToArray())
            {
                food.Push(item);
            }

            Queue<int> power = new();
            foreach (var item in Console.ReadLine().Split(", ").Select(int.Parse).ToArray())
            {
                power.Enqueue(item);
            }

            while (food.Any() && power.Any())
            {
                int playerStrong = food.Pop() + power.Dequeue();

                if(row < Peacs.GetLength(0) && playerStrong >= int.Parse(Peacs[row, col]))
                {
                    PeacsList.Add(Peacs[row, col + 1]);
                    row++;
                }
            }

            if(PeacsList.Count == 5)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (PeacsList.Any())
            {
                Console.WriteLine($"Conquered peaks:{Environment.NewLine}{string.Join(Environment.NewLine,PeacsList)}");
            }
        }
    }
}