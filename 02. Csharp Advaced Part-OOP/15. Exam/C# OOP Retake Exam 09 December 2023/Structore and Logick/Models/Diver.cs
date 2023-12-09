namespace NauticalCatchChallenge.Models
{
    using Contracts;
    using System.Collections.Generic;

    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> catchs;
        private double competitionPoints;
        private bool hasHealthIssues;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            catchs = new List<string>();
            competitionPoints = 0;
            hasHealthIssues = false;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Diver's name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch
            => catchs.AsReadOnly();

        public double CompetitionPoints
        {
            get => Math.Round(competitionPoints, 1);
            private set
            {
                competitionPoints = Math.Round(value, 1);
            }
        }

        public bool HasHealthIssues
        {
            get => hasHealthIssues;
            private set
            {
                hasHealthIssues = value;
            }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            catchs.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            HasHealthIssues = HasHealthIssues ? false : true;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {catchs.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
