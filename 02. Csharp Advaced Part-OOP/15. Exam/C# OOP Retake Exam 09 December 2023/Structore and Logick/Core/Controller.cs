namespace NauticalCatchChallenge.Core
{
    using NauticalCatchChallenge.Repositories;
    using Contracts;
    using NauticalCatchChallenge.Models;
    using NauticalCatchChallenge.Models.Contracts;
    using System;
    using System.Text;

    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fishs;

        public Controller()
        {
            divers = new DiverRepository();
            fishs = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = divers.GetModel(diverName);

            if (diver == null)
            {
                return $"{divers.GetType().Name} has no {diverName} registered for the competition.";
            }

            IFish fish = fishs.GetModel(fishName);

            if (fish == null)
            {
                return $"{fishName} is not allowed to be caught in this competition.";
            }

            if (diver.HasHealthIssues)
            {
                return $"{diverName} will not be allowed to dive, due to health issues.";
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);

                if (diver.OxygenLevel <= 0)
                {
                    diver.UpdateHealthStatus();
                }

                return $"{diverName} missed a good {fishName}.";
            }
            else if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    diver.UpdateHealthStatus();
                    return $"{diverName} hits a {fish.Points}pt. {fishName}.";
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);

                    if (diver.OxygenLevel <= 0)
                    {
                        diver.UpdateHealthStatus();
                    }

                    return $"{diverName} missed a good {fishName}.";
                }
            }

            diver.Hit(fish);
            return $"{diverName} hits a {fish.Points}pt. {fishName}.";
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in divers.Models
                .Where(x=>x.HasHealthIssues==false)
                .OrderByDescending(p =>p.CompetitionPoints)
                .ThenByDescending(c =>c.Catch.Count)
                .ThenBy(n => n.Name))
            {
                sb.AppendLine($"{diver}");
            }

            return sb.ToString().Trim();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            IDiver diver = null;

            if (diverType == "FreeDiver")
            {
                diver = new FreeDiver(diverName);
            }
            else if (diverType == "ScubaDiver")
            {
                diver = new ScubaDiver(diverName);
            }
            else
            {
                return $"{diverType} is not allowed in our competition.";
            }

            if (divers.GetModel(diverName) != null)
            {
                return $"{diverName} is already a participant -> {divers.GetType().Name}.";
            }

            divers.AddModel(diver);
            return $"{diverName} is successfully registered for the competition -> {divers.GetType().Name}.";
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();
            IDiver diver = divers.GetModel(diverName);
            List<string> fishsNames = new List<string>(diver.Catch);

            sb.AppendLine($"{diver}");
            sb.AppendLine($"Catch Report:");

            foreach (string fish in fishsNames)
            {
                IFish f = fishs.GetModel(fish);
                sb.AppendLine($"{f}");
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery() // ?
        {
            int recoveryDivers = divers.Models.Where(x => x.HasHealthIssues).Count();

            foreach (var diver in divers.Models.Where(x => x.HasHealthIssues ))
            {
                diver.RenewOxy();
                diver.UpdateHealthStatus();
            }

            return $"Divers recovered: {recoveryDivers}";
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            IFish fish = null;

            if (fishType == "ReefFish")
            {
                fish = new ReefFish(fishName, points);
            }
            else if (fishType == "DeepSeaFish")
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == "PredatoryFish")
            {
                fish = new PredatoryFish(fishName, points);
            }
            else
            {
                return $"{fishType} is forbidden for chasing in our competition.";
            }

            if (fishs.GetModel(fishName) != null)
            {
                return $"{fishName} is already allowed -> {fishs.GetType().Name}.";
            }

            fishs.AddModel(fish);
            return $"{fishName} is allowed for chasing.";
        }
    }
}
