namespace RubberDuckDebugers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] first = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] second = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            Queue<int> queue = new(first);
            Stack<int> stack = new(second);

            int darth = default;
            int Thor = default;
            int Big = default;
            int small = default;
            while (true)
            {
                if (queue.Any() == false || stack.Any() == false)
                {
                    break;
                }
                int curentQueue = queue.Dequeue();
                int curentStack = stack.Pop();
                int result = curentQueue * curentStack;

                if (result >= 0 && result <= 60)
                {
                    darth++;
                    continue;
                }
                else if (result >= 61 && result <= 120)
                {
                    Thor++;
                    continue;
                }
                else if (result >= 121 && result <= 180)
                {
                    Big++;
                    continue;
                }
                else if (result >= 181 && result <= 240)
                {
                    small++;
                    continue;
                }

                queue.Enqueue(curentQueue);
                stack.Push(curentStack - 2);
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {darth}");
            Console.WriteLine($"Thor Ducky: {Thor}");
            Console.WriteLine($"Big Blue Rubber Ducky: {Big}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {small}");
        }
    }
}