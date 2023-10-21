namespace OffroadChallenge
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] fuelInput = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int[] indexInput = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int[] needetFuelInput = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            Stack<int> fuel = new Stack<int>();
            Queue<int> index = new Queue<int>();
            Queue<int> neadetFuel = new Queue<int>();

            foreach (var f in fuelInput)
            {
                fuel.Push(f);
            }

            foreach (var i in indexInput)
            {
                index.Enqueue(i);
            }

            foreach (var n in needetFuelInput)
            {
                neadetFuel.Enqueue(n);
            }

            int count = 0;

            while (count != 4)
            {
                int fuelHave = fuel.Pop() - index.Dequeue();
                if(fuelHave >= neadetFuel.Dequeue())
                {
                    count++;
                    Console.WriteLine($"John has reached: Altitude {count}");
                    continue;
                }
                Console.WriteLine($"John did not reach: Altitude {count + 1}");
                break;
            }

            if(count == 4)
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
            else if(count == 0)
            {
                Console.WriteLine($"John failed to reach the top.{Environment.NewLine}John didn't reach any altitude.");
            }
            else
            {
                Console.WriteLine("John failed to reach the top.");
                Console.Write("Reached altitudes: ");
                for (int i = 1; i <= count; i++)
                {
                    Console.Write(count == i? $"Altitude {i} ": $"Altitude {i}, ");
                }
            }
        }
    }
}