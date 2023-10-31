using System;
using System.Linq;
using System.Text;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;
        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }

        public string LeagueStandings()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("***League Standings***");

            string text = string.Join(Environment.NewLine, teams.Models.OrderByDescending(x => x.PointsEarned).ThenByDescending(x => x.OverallRating).ThenBy(x => x.Name));
            stringBuilder.AppendLine(text);
            return stringBuilder.ToString().Trim();
        }

        public string NewContract(string playerName, string teamName)
        {

            IPlayer curentPlayer = players.GetModel(playerName);
            if (curentPlayer == null)
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, players.GetType().Name);
            }

            ITeam curentTeam = teams.GetModel(teamName);
            if (curentTeam == null)
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, teams.GetType().Name);
            }

            if (curentPlayer.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, curentPlayer.Team);
            }

            curentTeam.SignContract(curentPlayer);
            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);


            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                firstTeam.Lose();
                secondTeam.Win();
                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }

            firstTeam.Draw();
            secondTeam.Draw();
            return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);

        }

        public string NewPlayer(string typeName, string name)
        {
            IPlayer player = null;
            string[] validClases = new string[] { "Goalkeeper", "CenterBack", "ForwardWing" };

            if (validClases.Contains(typeName) == false)
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (players.ExistsModel(name))
            {
                IPlayer ppp = players.GetModel(name);
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, players.GetType().Name, ppp.GetType().Name);
            }

            if (typeName == "Goalkeeper") { player = new Goalkeeper(name); }
            else if (typeName == "CenterBack") { player = new CenterBack(name); }
            else if (typeName == "ForwardWing") { player = new ForwardWing(name); }
            players.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, teams.GetType().Name);
            }

            ITeam team = new Team(name);
            teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, teams.GetType().Name);
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"***{teamName}***");
            ITeam team = teams.GetModel(teamName);
            string text = string.Join(Environment.NewLine, team.Players.OrderByDescending(x => x.Rating).ThenBy(x => x.Name));
            stringBuilder.AppendLine(text);
            return stringBuilder.ToString().Trim();
        }
    }
}
