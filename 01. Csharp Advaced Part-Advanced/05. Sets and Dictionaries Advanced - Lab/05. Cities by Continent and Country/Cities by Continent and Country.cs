namespace _05._Cities_by_Continent_and_Country
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> colecia = new();
            int citiesCount = int.Parse(Console.ReadLine());

            for (int citiesInARow = 0; citiesInARow < citiesCount; citiesInARow++)
            {
                string[] citiesArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                string continent = citiesArg[0];
                string country = citiesArg[1];
                string citi = citiesArg[2];

                if(colecia.ContainsKey(continent) == false)
                {
                    colecia[continent] = new Dictionary<string, List<string>>();
                }

                if (colecia[continent].ContainsKey(country) == false)
                {
                    colecia[continent][country]= new List<string>();
                }

                colecia[continent][country].Add(citi);
            }

            foreach (var continentCountry in colecia)
            {
                Console.WriteLine($"{continentCountry.Key}:");

                foreach (var citii in continentCountry.Value)
                {
                    Console.WriteLine($"  {citii.Key} -> {string.Join(", ", citii.Value)}");
                }
            }
        }
    }
}