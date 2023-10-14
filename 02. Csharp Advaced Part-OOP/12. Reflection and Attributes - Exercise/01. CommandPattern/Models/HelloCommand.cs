﻿namespace CommandPattern.Models
{
    using CommandPattern.Core.Contracts;
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
            => $"Hello, {args[0]}";
    }
}
