namespace _7._Hot_Potato
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] playersNameInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> playersName = new(playersNameInput);
            int muvmentBeforBurn = int.Parse(Console.ReadLine());
            
            while (playersName.Count > 1)
            {
                for (int i = 1; i < muvmentBeforBurn; i++)
                {
                    string curentPlayer = playersName.Dequeue();
                    playersName.Enqueue(curentPlayer);
                }
                Console.WriteLine($"Removed {playersName.Dequeue()}");
            }
            Console.WriteLine($"Last is {playersName.Dequeue()}");
        }
    }
}