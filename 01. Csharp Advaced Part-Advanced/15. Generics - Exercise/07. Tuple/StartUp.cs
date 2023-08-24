namespace Tuple
{
    public class StartUp
    {
        public static void Main()
        {
            string[] nameAdres = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string, string> firstLine = new($"{nameAdres[0]} {nameAdres[1]}" , nameAdres[2]);

            string[] personBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string, int> secondLine = new(personBeer[0] , int.Parse(personBeer[1]));

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<int, double> theeLines = new(int.Parse(numbers[0]), double.Parse(numbers[1]));

            Console.WriteLine(firstLine);
            Console.WriteLine(secondLine);
            Console.WriteLine(theeLines);
        }
    }
}