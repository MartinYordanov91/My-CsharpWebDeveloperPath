namespace CommandPattern.Utilities
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArg = args.Split(' ');

            string comandName = cmdArg[0];
            string[] invokeArg = cmdArg.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();

            Type cmdType = assembly
                 .GetTypes()
                 .FirstOrDefault(t => t.Name == $"{comandName}Command");

            if (cmdType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            MethodInfo executeMethodInfo = cmdType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "Execute");

            if (executeMethodInfo == null)
            {
                throw new InvalidOperationException("Command does not implement required pattrern!");
            }

            object cmdInstance = Activator.CreateInstance(cmdType);
            string result = (string)executeMethodInfo.Invoke(cmdInstance, new object[]{invokeArg});

            return result;
        }
    }
}
