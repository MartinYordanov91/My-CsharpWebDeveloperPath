namespace _10._ForceBook
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forseBoock = new();
            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] comandArg = comand.Contains('|') ? comand.Split('|', StringSplitOptions.RemoveEmptyEntries) : comand.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string members = comand.Contains('|') ? comandArg[1].Trim() : comandArg[0].Trim();
                string side = comand.Contains('|') ? comandArg[0].Trim() : comandArg[1].Trim();

                if (comand.Contains('|'))
                {
                    bool isThear = forseBoock.Any(x => x.Value.Contains(members));
                    if (isThear == false)
                    {
                        if (forseBoock.ContainsKey(side) == false)
                        {
                            forseBoock[side] = new List<string>();
                        }
                        forseBoock[side].Add(members);
                    }
                }
                else
                {
                    bool isThear = forseBoock.Any(x => x.Value.Contains(members));
                    if (isThear == false)
                    {
                        if (forseBoock.ContainsKey(side) == false)
                        {
                            forseBoock[side] = new List<string>();
                        }
                        forseBoock[side].Add(members);
                        Console.WriteLine($"{members} joins the {side} side!");
                    }
                    else
                    {
                        if (forseBoock.ContainsKey(side) == false)
                        {
                            forseBoock[side] = new List<string>();
                        }
                        forseBoock.First(x=>x.Value.Contains(members)).Value.Remove(members);
                        forseBoock[side].Add(members);
                        Console.WriteLine($"{members} joins the {side} side!");
                    }
                }
            }
            foreach (var sid in forseBoock.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                if (sid.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {sid.Key}, Members: {sid.Value.Count}");
                    foreach (var mem in sid.Value.OrderBy(x=>x))
                    {
                        Console.WriteLine($"! {mem}");
                    }
                }
            }
        }
    }
}