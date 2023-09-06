namespace TempleOfDoom
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] toolsArraysInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] substancesArraysInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] challengeArraysInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> tools = new(toolsArraysInput);
            Stack<int> substances = new(substancesArraysInput);
            List<int> challengers = new(challengeArraysInput);

            while (true)
            {
                if (tools.Any() == false ||
                    substances.Any() == false ||
                    challengers.Any() == false)
                {
                    break;
                }
                int curentTool = tools.Dequeue();
                int curentSubstrance = substances.Pop();
                int curentResult = curentTool * curentSubstrance;

                if (challengers.Any(x => x == curentResult))
                {
                    challengers.Remove(challengers.FirstOrDefault(x => x == curentResult));
                    continue;
                }

                tools.Enqueue(++curentTool);

                if (curentSubstrance - 1 > 0)
                {
                    substances.Push(--curentSubstrance);
                }
            }
            if (challengers.Any())
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Any())
            {
                Console.WriteLine("Tools: " + string.Join(", ", tools));
            }
            if (substances.Any())
            {
                Console.WriteLine("Substances: " + string.Join(", ", substances));
            }
            if (challengers.Any())
            {
                Console.WriteLine("Challenges: " + string.Join(", ", challengers));
            }
        }
    }
}