
namespace AuthorProblem
{
    using System.Reflection;
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            foreach (var method in type.GetMethods((BindingFlags)60))
            {
                AuthorAttribute[] attr = method.GetCustomAttributes<AuthorAttribute>().ToArray();
                foreach (var attribute in attr)
                {
                    Console.WriteLine($"{type.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}
