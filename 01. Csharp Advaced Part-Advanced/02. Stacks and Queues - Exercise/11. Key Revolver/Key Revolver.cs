namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int bulletPrice = int.Parse(Console.ReadLine()); // цена за патрон
            int gunBarrel = int.Parse(Console.ReadLine());  // капацитет на пълнителя
            Stack<int> bulletsHave = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray()); //стойност и количество патрони
            Queue<int> locks = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray()); // ключалки и тяхната стойност
            int tresure = int.Parse(Console.ReadLine());
            int countBulletsShots = 0;

            while (bulletsHave.Any()) // докато имамем патрони
            {
                
                if (bulletsHave.Peek() <= locks.Peek()) //дали ключалката ще бъде оцелена
                {
                    locks.Dequeue(); // оцелена е вадим я
                    Console.WriteLine("Bang!"); // коментираме
                }
                else
                {
                    Console.WriteLine("Ping!"); // не я оцелва коментираме
                }
                bulletsHave.Pop(); // махаме патрона 
                countBulletsShots++; // броим патрона

                if (countBulletsShots % gunBarrel == 0 && bulletsHave.Count > 0) // проверявам дали е време за презареждане и дали има смисъл да презареждам
                {
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0) // проверка дали сме стигнали до трезора
                {
                    bulletPrice *= countBulletsShots; // разход патрони
                    Console.WriteLine($"{bulletsHave.Count} bullets left. Earned ${tresure - bulletPrice}"); // резултат при успех
                    return; // преключване на програмата
                }

            }

            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}"); // коментар при не успех
        }
    }
}