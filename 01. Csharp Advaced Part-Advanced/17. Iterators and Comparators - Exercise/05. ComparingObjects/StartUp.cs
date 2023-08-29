namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string argomends = string.Empty;

            while ((argomends = Console.ReadLine()) != "END")
            {
                string[] arg = argomends.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new(arg[0], int.Parse(arg[1]), arg[2]);
                people.Add(person);
            }

            int compareIndex = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[compareIndex];
            int equalPeople = 0;
            int diferent = 0;

            foreach (var item in people)
            {
                if (personToCompare.CompareTo(item) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    diferent++;
                }
            }
            if(equalPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {diferent} {people.Count}");
            }
        }
    }
}