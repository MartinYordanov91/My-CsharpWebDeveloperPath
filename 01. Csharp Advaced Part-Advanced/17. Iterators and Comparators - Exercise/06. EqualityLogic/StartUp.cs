using ComparingObjects;

namespace EqualityLogic
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Person> hashPersons = new();
            SortedSet<Person> sortPerson = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] curentPerson = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new(curentPerson[0], int.Parse(curentPerson[1]));
                sortPerson.Add(person);
                hashPersons.Add(person);
            }

            Console.WriteLine(hashPersons.Count());
            Console.WriteLine(sortPerson.Count());
        }
    }
}