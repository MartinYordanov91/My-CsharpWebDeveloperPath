namespace ThePartyReservationFilterModule;
using System;
using System.Xml;

internal class ThePartyReservationFilterModule
{
    private static void Main()
    {
        List<string> partyMembers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries) .ToList();
        Dictionary<string, Predicate<string>> filters = new();

        string comand = string.Empty;

        while ((comand = Console.ReadLine()) != "Print")
        {
            string[] comandArg = comand.Split(";", StringSplitOptions.RemoveEmptyEntries);
            Predicate<string> filter = GetPredicate(comand);

            if (comandArg[0].StartsWith("Add"))
            {
                string key = comandArg[1] + " - " + comandArg[2];
                filters.Add(key, filter);
            }
            else
            {
                string key = comandArg[1] + " - " + comandArg[2];
                if (filters.ContainsKey(key))
                {
                    filters.Remove(key);
                }
            }
        }

        foreach (Predicate<string> filter in filters.Values)
        {
            partyMembers.RemoveAll(filter);
        }

        Console.WriteLine(string.Join(" " , partyMembers));
    }
    public static Predicate<string> GetPredicate(string comand)
    {
        string[] comandArg = comand.Split(";", StringSplitOptions.RemoveEmptyEntries);

        if (comandArg[1] == "Starts with")
        {
            return x => x.StartsWith(comandArg[2]);
        }
        if (comandArg[1] == "Ends with")
        {
            return x => x.EndsWith(comandArg[2]);
        }
        if (comandArg[1] == "Length")
        {
            int lenght = int.Parse(comandArg[2]);
            return x => x.Length == lenght;
        }

        return x => x.Contains(comandArg[2]);
    }
}