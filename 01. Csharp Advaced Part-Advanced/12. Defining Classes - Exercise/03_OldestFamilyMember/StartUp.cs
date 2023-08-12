namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] curentPerson = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries);
                string name = curentPerson[0];
                int age = int.Parse(curentPerson[1]);

                Person person = new Person(name , age);
                family.AddMember(person);
            }

            Person olderPerson = family.GetOldestMember();
            Console.WriteLine(olderPerson.Name +" "+olderPerson.Age);
            ;
        }
    }
}