namespace Renovators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get { return Renovators.Count; } }


        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (NeededRenovators <= Count)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            Renovators.Add(renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if(Renovators.Any(n=>n.Name == name))
            {
                Renovators.Remove(Renovators.Find(x => x.Name == name));
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int remulvRenovators = Renovators.RemoveAll(x => x.Type == type);
            return remulvRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            if(Renovators.Any(x =>x.Name == name))
            {
                Renovators.First(x=>x.Name == name).Hired = true;
                return Renovators.First(x => x.Name == name);
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
            => Renovators.Where(c => c.Days >= days).ToList();

        public string Report()
            => $"Renovators available for Project {Project}:"
            + Environment.NewLine
            + string.Join(Environment.NewLine, Renovators.FindAll(x => !x.Hired));

    }
}
