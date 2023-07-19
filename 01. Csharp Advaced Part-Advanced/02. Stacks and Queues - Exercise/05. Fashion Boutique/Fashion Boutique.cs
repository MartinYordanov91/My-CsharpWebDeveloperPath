namespace _05._Fashion_Boutique
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothingParts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int countOfRack = 0;

            Stack<int> clothingBoxes = new(clothingParts);

            int rackCapasity = int.Parse(Console.ReadLine());
            int testRackCapasity = 0;

            while (clothingBoxes.Count > 0)
            {
                if (testRackCapasity + clothingBoxes.Peek() <= rackCapasity)
                {
                    testRackCapasity += clothingBoxes.Pop();
                }
                else
                {
                    testRackCapasity = 0;
                    countOfRack++;
                }
            }
            if (testRackCapasity > 0)
            {
                countOfRack++;
            }
            Console.WriteLine(countOfRack);
        }
    }
}