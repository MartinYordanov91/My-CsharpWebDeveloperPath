namespace GenericScale
{
    public class StartUp
    {
        public static void Main()
        {
            EqualityScale<int> dafds = new EqualityScale<int>(5, 6);
            Console.WriteLine(dafds.AreEqual());
        }
    }
}