namespace Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(", " , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Lake<int> frogi = new(list);
            Console.WriteLine(string.Join(", " , frogi));
        }
    }
}