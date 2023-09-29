namespace Shapes
{
    using Core;
    using Core.Interface;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine starter = new Engine();
            starter.Start();
        }
    }
}