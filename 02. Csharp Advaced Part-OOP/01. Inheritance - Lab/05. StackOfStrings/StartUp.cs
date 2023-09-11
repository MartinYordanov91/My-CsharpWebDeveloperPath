namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings strings = new StackOfStrings();

            Console.WriteLine(strings.IsEmpty());

            strings.AddRange(new string[] {"masha"  , "melisa" , "anjelika" });

            Console.WriteLine(string.Join(", " , strings));
        }
    }
}