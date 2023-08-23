namespace GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main()
        {
            int countOfText = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfText; i++)
            {
                int curentText = int.Parse(Console.ReadLine());
                Box<int> text = new Box<int>(curentText);
                Console.WriteLine(text);
            }
        }
    }
}