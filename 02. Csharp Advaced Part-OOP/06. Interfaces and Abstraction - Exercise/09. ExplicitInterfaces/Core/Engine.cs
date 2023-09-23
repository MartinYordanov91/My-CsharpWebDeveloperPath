namespace ExplicitInterfaces.Core
{
    using ExplicitInterfaces.Models;
    using ExplicitInterfaces.Models.Interface;
    using Interface;
    public class Engine : IEngine
    {
        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IPerson person = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
                IResident resident = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

                Console.WriteLine($"{person.GetName()}{Environment.NewLine}{resident.GetName()}");
            }
        }
    }
}
