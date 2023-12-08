namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class University : IUniversity
    {
        private List<int> requiredSubjects;
        private readonly string[] colection;
        private int id;
        private string name;
        private string category;
        private int capacity;

        public University(int id, string name, string category, int capacity, ICollection<int> require)
        {
            colection = new string[] { "Technical", "Economical", "Humanity" };

            Id = id;
            Name = name;
            Category = category;
            Capacity = capacity;
            requiredSubjects = require.ToList();
        }

        public int Id
        {
            get => id;
            private set => id = value;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public string Category
        {
            get => category;
            private set
            {
                if (!colection.Contains(value))
                {
                    throw new ArgumentException($"University category {value} is not allowed in the application!");
                }
                category = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("University capacity cannot be a negative value!");
                }
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects 
            => requiredSubjects.AsReadOnly();
    }
}
