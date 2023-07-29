namespace _07._The_V_Logger
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> theVlogers = new();

            string text = string.Empty;
            while ((text = Console.ReadLine()) != "Statistics")
            {
                string[] information = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (text.Contains("joined"))
                {
                    string name = information[0];
                    if (theVlogers.ContainsKey(name) == false)
                    {
                        theVlogers[name] = new Dictionary<string, HashSet<string>>();
                        theVlogers[name].Add("followers", new HashSet<string>());
                        theVlogers[name].Add("following", new HashSet<string>());
                    }
                }
                else if (text.Contains("followed"))
                {
                    string name = information[0];
                    string nameFolloed = information[2];

                    if (theVlogers.ContainsKey(nameFolloed)
                        && theVlogers.ContainsKey(name)
                        && name != nameFolloed)
                    {
                        theVlogers[nameFolloed]["followers"].Add(name);
                        theVlogers[name]["following"].Add(nameFolloed);

                    }
                }

            }
            int first= 1;
            Console.WriteLine($"The V-Logger has a total of {theVlogers.Count} vloggers in its logs.");

            foreach (var vloger in theVlogers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{first}. {vloger.Key} : {vloger.Value["followers"].Count} followers, {vloger.Value["following"].Count} following");
                if(first == 1)
                {
                    foreach (var item in vloger.Value["followers"].OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                first++;
            }
        }
    }
}