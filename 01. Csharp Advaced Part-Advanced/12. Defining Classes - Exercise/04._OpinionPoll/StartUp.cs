namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> peoples = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] curentPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = curentPerson[0];
                int age = int.Parse(curentPerson[1]);

                Person person = new Person(name, age);
                if (age > 30)
                {
                    peoples.Add(person);
                }
            }

            foreach (Person person in peoples.OrderBy(n => n.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}