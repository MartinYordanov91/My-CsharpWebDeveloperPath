namespace _03._Maximum_and_Minimum_Element
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int numQueries = int.Parse(Console.ReadLine());
            Stack<int> integerStack = new();

            for (int i = 0; i < numQueries; i++)
            {
                int[] curentQueries = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (curentQueries[0] == 1)
                {
                    integerStack.Push(curentQueries[1]);
                }
                else if (curentQueries[0] == 2)
                {
                    integerStack.Pop();
                }
                else if (curentQueries[0] == 3)
                {
                    if(integerStack.Any()== false) { continue; }
                    Console.WriteLine(integerStack.Max());
                }
                else if (curentQueries[0] == 4)
                {
                    if (integerStack.Any() == false) { continue; }
                    Console.WriteLine(integerStack.Min());
                }

            }
            Console.WriteLine(string.Join(", " , integerStack));
        }
    }
}