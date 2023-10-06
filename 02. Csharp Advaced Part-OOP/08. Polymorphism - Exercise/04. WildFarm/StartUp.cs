namespace WildFarm
{
    using Core;
    using Core.Interface;
    using Factories;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}