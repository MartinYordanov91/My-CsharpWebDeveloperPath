namespace GenericBoxОfString
{
    public class StartUp
    {
        public static void Main()
        {
            int countOfText = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfText; i++)
            {
                string curentText = Console.ReadLine();
                Box<string> text = new Box<string>(curentText);
                Console.WriteLine(text);
            }
        }
    }
}