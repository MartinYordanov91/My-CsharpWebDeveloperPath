namespace CommandPattern.IO
{
    using System;
    using IO.Contracts;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();
    }
}
