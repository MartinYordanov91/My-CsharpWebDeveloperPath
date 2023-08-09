namespace PredicateParty;
using System;
internal class PredicateParty
{
    private static void Main()
    {
        List<string> partyEnimal = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string comand = string.Empty;

        while ((comand = Console.ReadLine()) != "Party!")
        {
            string[] comandArg = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Predicate<string> predicat = GetPredicate(comandArg[1], comandArg[2]);

            if (comandArg[0] == "Remove")
            {
                partyEnimal.RemoveAll(predicat);
            }
            else if (comandArg[0] == "Double")
            {
                List<string> dubleNames = partyEnimal.FindAll(predicat);

                if (dubleNames.Any())
                {
                    partyEnimal.AddRange(dubleNames);
                }
            }
        }
        if (partyEnimal.Any())
        {
            Console.WriteLine($"{string.Join(", ", partyEnimal)} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }

    public static Predicate<string> GetPredicate(string comand, string argoment)
    {
        if (comand == "StartsWith")
        {
            return x => x.StartsWith(argoment);
        }

        if (comand == "EndsWith")
        {
            return x => x.EndsWith(argoment);
        }

        int lenght = int.Parse(argoment);
        return x => x.Length == lenght;
    }
}