using BirthdayCelebrationsrol.Core.Interface;
using BirthdayCelebrationsrol.Core;

namespace BirthdayCelebrationsrol
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