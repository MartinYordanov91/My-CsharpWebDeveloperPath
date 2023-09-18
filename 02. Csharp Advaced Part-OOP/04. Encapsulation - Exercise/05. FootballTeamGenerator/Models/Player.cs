using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;


        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;


        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException("A name should not be empty.");
                }
                name = value;
            }
        }
        private int Endurance
        {
            get => endurance;
            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new AggregateException("Endurance should be between 0 and 100.");
                }
                endurance = value;
            }
        }
        private int Sprint
        {
            get => sprint;
            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new AggregateException("Sprint should be between 0 and 100.");
                }
                sprint = value;
            }
        }
        private int Dribble
        {
            get => dribble;
            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new AggregateException("Dribble should be between 0 and 100.");
                }
                dribble = value;
            }
        }
        private int Passing
        {
            get => passing;
            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new AggregateException("Passing should be between 0 and 100.");
                }
                passing = value;
            }
        }
        private int Shooting
        {
            get => shooting;
            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new AggregateException("Shooting should be between 0 and 100.");
                }
                shooting = value;
            }
        }
        public double Stats
        {
            get
            {
                double stats = (endurance + sprint + dribble + passing + shooting);
                return stats;
            }

        }
    }
}