namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DarkKnight knight = new("Marto", 100);
            Console.WriteLine(knight);
        }
    }
}