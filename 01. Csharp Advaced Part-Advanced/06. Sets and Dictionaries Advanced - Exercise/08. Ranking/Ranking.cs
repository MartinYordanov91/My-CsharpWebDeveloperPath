namespace _08._Ranking
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPass = new();

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "end of contests")
            {
                //Part One Interview: success
                //Js Fundamentals: JSFundPass
                //C# Fundamentals:fundPass
                //Algorithms: fun
                string[] comandArg = comand.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = comandArg[0];
                string password = comandArg[1];
                contestPass.Add(contest, password);
            }

            //C# Fundamentals=>fundPass=>Tanya=>350
            //Algorithms=>fun=>Tanya=>380
            //Part One Interview => success => Nikola => 120
            Dictionary<string, Dictionary<string, int>> parciciant = new();

            while ((comand = Console.ReadLine()) != "end of submissions")
            {
                string[] comandArg = comand.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = comandArg[0];
                string password = comandArg[1];
                string name = comandArg[2];
                int point = int.Parse(comandArg[3]);

                if (contestPass.ContainsKey(contest) == false || contestPass[contest] != password)
                {
                    continue;
                }

                if (parciciant.ContainsKey(name) == false)
                {
                    parciciant[name] = new Dictionary<string, int>();
                }

                if (parciciant[name].ContainsKey(contest) == false)
                {
                    parciciant[name].Add(contest, 0);
                }

                if (parciciant[name][contest] < point)
                {
                    parciciant[name][contest] = point;
                }

            }
            /*
                    Best candidate is Tanya with total 1350 points.
                    Ranking:
                    Nikola
                    # C# Fundamentals -> 200
                    # Part One Interview -> 120
                    Tanya
                    # Js Fundamentals -> 400
                    # Algorithms -> 380
                    # C# Fundamentals -> 350
                    # Part One Interview -> 220
                 */
            int sum = 0;
            string higer = string.Empty;
            foreach (var parci in parciciant)
            {
                int curentSum = 0;
                foreach (var item in parci.Value)
                {
                    curentSum += item.Value;
                }

                if(curentSum > sum)
                {
                    sum = curentSum;
                    higer = parci.Key;
                }
            }
            Console.WriteLine($"Best candidate is {higer} with total {sum} points.");
            Console.WriteLine("Ranking:");
            foreach (var parci in parciciant.OrderBy(x=>x.Key))
            {
                Console.WriteLine(parci.Key);
                foreach (var item in parci.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}