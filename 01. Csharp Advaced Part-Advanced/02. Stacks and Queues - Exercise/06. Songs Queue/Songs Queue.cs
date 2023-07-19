namespace _06._Songs_Queue
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songColektion = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songQueue = new(songColektion);

            while (songQueue.Any())
            {
                string comandArg = Console.ReadLine();

                if (comandArg.StartsWith("Add"))
                {
                    string[] comand = comandArg.Split("Add", StringSplitOptions.RemoveEmptyEntries);
                    string song = comand[0].Trim();

                    if (songQueue.Contains(song) == false)
                    {
                        songQueue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (comandArg == "Play")
                {
                    songQueue.Dequeue();
                }
                else if (comandArg == "Show")
                {
                    Console.WriteLine(string.Join(", ", songQueue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}