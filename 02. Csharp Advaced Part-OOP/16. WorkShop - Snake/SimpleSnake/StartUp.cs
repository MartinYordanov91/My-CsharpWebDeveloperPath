namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(70, 30);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall,snake);
            engine.Run();
        }
    }
}
