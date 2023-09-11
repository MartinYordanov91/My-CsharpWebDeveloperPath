namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList strings = new RandomList() { "marto", "nikolaj", "gosho" };
            Console.WriteLine(strings.RandomString());
            Console.WriteLine(string.Join(", " , strings));
        }
    }
}