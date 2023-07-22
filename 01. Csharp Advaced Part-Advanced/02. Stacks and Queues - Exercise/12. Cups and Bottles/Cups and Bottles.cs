namespace _12._Cups_and_Bottles
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()); // прочитане на брой чаши и тяхният капацитет
            Stack<int> bottles = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()); // прочитане на количество ботилки и тяхното съдържание в литри 
            int wastedWater = 0;

            while (cups.Any() && bottles.Any()) // докато има и от двете 
            {
                if (cups.Peek() <= bottles.Peek()) // ако имаме повече вода от колкото чашата побира
                {
                    wastedWater += bottles.Pop() - cups.Dequeue(); // сумиране на остатъка от вода и изкарване на чашата и бутилката
                }
                else // в случей че чашата побира повече от колкото има в шишето
                {
                    int curentWater = 0;
                    while (bottles.Count > 0 && cups.Peek() > curentWater) // изпразвам ботилки докато свършат или докато ми стигне водата да напълня чашата
                    {
                        curentWater += bottles.Pop(); // сумирам литрите на извадените бутилки
                    }

                    if (curentWater >= cups.Peek()) // проверявам дали водата ми стига
                    {
                        wastedWater += curentWater - cups.Dequeue(); // ако стига махам чашата
                    }

                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" " , bottles )}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}