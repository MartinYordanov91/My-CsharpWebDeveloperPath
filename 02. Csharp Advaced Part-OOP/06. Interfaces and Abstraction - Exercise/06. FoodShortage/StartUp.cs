using FoodShortage.Core;
using FoodShortage.Core.Interface;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}