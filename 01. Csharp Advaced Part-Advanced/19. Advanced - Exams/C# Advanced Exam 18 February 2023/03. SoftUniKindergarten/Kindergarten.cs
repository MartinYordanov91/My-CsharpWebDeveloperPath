using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private List<Child> registry;
        private int capacity;
        private string name;

        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public int ChildrenCount
        {
            get => registry.Count;
        }

        public string Name
        {
            get => name;
            private set { name = value; }
        }

        public int Capacity
        {
            get => capacity;
            private set { capacity = value; }
        }


        public List<Child> Registry
        {
            get => registry;
            private set { registry = value; }
        }

        public bool AddChild(Child child)
        {
            if (this.capacity > this.registry.Count)
            {
                this.registry.Add(child);
                return true;
            }
            return false;
        }
        public bool RemoveChild(string childFullName)
        {
            string firstName = childFullName.Split().First();
            string lastName = childFullName.Split().Last();

            if (registry.Any(f => f.FirstName == firstName && f.LastName == lastName))
            {
                Child childForRemulv = registry.First(f => f.FirstName == firstName && f.LastName == lastName);
                registry.Remove(childForRemulv);

                return true;
            }
            return false;
        }
        public Child GetChild(string childFullName)
        {
            string firstName = childFullName.Split().First();
            string lastName = childFullName.Split().Last();

            if (registry.Any(f => f.FirstName == firstName && f.LastName == lastName))
            {
                Child childForRemulv = registry.First(f => f.FirstName == firstName && f.LastName == lastName);

                return childForRemulv;
            }
            return null;
        }
        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {this.name}:");

            foreach (var child in registry.OrderByDescending(a=>a.Age).ThenBy(l => l.LastName) .ThenBy(f=>f.FirstName))
            {
                sb.AppendLine(child.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
