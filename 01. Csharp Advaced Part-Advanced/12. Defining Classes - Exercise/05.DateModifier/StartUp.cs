using Microsoft.VisualBasic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            int different = DateModifier.GetDifferenceInDays(start , end);
            Console.WriteLine(different);
        }
    }
}