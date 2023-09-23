namespace ExplicitInterfaces
{
    using Core;
    using Core.Interface;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}