using System.Text;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main()
        {
            string[] nameAdres = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string, string , string> firstLine = new($"{nameAdres[0]} {nameAdres[1]}", nameAdres[2], string.Join(" ",nameAdres[3..]));

            string[] personBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string, int , bool> secondLine = new(personBeer[0], int.Parse(personBeer[1]), personBeer[2] == "drunk");

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string, double , string> theeLines = new(numbers[0], double.Parse(numbers[1]), numbers[2]);

            Console.WriteLine(firstLine);
            Console.WriteLine(secondLine);
            Console.WriteLine(theeLines);
        }
    }
}