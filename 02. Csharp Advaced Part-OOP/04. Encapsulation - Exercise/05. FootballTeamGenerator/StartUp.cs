using FootballTeamGenerator.Models;
using System.Xml.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "END")
            {
                try
                {
                    string curentcomand = comand.Split(";", StringSplitOptions.RemoveEmptyEntries)[0];
                    if (curentcomand == "Team")
                    {
                        string teamName = comand.Split(";", StringSplitOptions.RemoveEmptyEntries)[1];
                        Team team = new(teamName);
                        teams.Add(team);
                    }
                    else if (curentcomand == "Add")
                    {
                        string[] tokens = comand
                            .Split(";", StringSplitOptions.RemoveEmptyEntries);

                        if (teams.Any(t => t.Name == tokens[1]) == false)
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }

                        Team team = teams.First(t => t.Name == tokens[1]);
                        Player player = new(tokens[2],
                            int.Parse(tokens[3]),
                            int.Parse(tokens[4]),
                            int.Parse(tokens[5]),
                            int.Parse(tokens[6]),
                            int.Parse(tokens[7])
                            );
                        team.AddPlayer(player);

                    }
                    else if (curentcomand == "Remove")
                    {
                        string teamName = comand
                            .Split(";", StringSplitOptions.RemoveEmptyEntries)[1];
                        string playerName = comand
                            .Split(";", StringSplitOptions.RemoveEmptyEntries)[2];

                        if (teams.Any(t => t.Name == teamName) == false)
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                            continue;
                        }

                        Team team = teams.First(t => t.Name == teamName);
                        team.RemovePlayer(playerName);
                    }
                    else if (curentcomand == "Rating")
                    {
                        string teamName = comand
                           .Split(";", StringSplitOptions.RemoveEmptyEntries)[1];
                        if (teams.Any(t => t.Name == teamName) == false)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        Team team = teams.First(t => t.Name == teamName);
                        Console.WriteLine(team);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}