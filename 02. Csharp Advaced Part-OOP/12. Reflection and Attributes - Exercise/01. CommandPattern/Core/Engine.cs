namespace CommandPattern.Core
{
    using Contracts;
    using IO.Contracts;
    using IO;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter cmdinterpreter;

        private Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public Engine(ICommandInterpreter commandInterpreter)
            :this()
        {
            this.cmdinterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = this.reader.ReadLine();
                string result = this.cmdinterpreter.Read(inputLine);
                this.writer.WriteLine(result);
            }
        }
    }
}
