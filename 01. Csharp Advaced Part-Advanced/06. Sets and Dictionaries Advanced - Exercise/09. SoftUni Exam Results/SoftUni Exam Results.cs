namespace _09._SoftUni_Exam_Results
{
    using System;
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> users = new();
            Dictionary<string, int> languages = new();
            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "exam finished")
            {
                string[] commandArg = comand.Split("-", StringSplitOptions.RemoveEmptyEntries);

                if (commandArg[1] == "banned")
                {
                    if (users.ContainsKey(commandArg[0]))
                    {
                        users.Remove(commandArg[0]);
                    }
                    continue;
                }

                string username = commandArg[0];
                string language = commandArg[1];
                int points = int.Parse(commandArg[2]);

                if (users.ContainsKey(username) == false)
                {
                    users[username] = 0;
                }

                if(languages.ContainsKey(language)== false)
                {
                    languages[language] = 0;
                }

                if(users[username] < points)
                {
                    users[username] = points;
                }  
                
                languages[language] += 1;
            }
            Console.WriteLine("Results:");
            foreach (var use in users.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{use.Key} | {use.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var lan in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{lan.Key} - {lan.Value}");
            }
        }
    }
}