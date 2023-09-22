using BorderControl.Core.Interface;
using BorderControl.Models;
using BorderControl.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IIdentification> society = new List<IIdentification>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] infoArg = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (infoArg.Length == 2)
                {
                    IIdentification robot = new Robots(infoArg[0], infoArg[1]);
                    society.Add(robot);
                }
                else
                {
                    IIdentification citizen = new Citizens(infoArg[0], int.Parse(infoArg[1]), infoArg[2]);
                    society.Add(citizen);
                }
            }
            string lastDigits = Console.ReadLine();

            foreach (var identificate in society)
            {
                if (identificate.Id.EndsWith(lastDigits))
                {
                    Console.WriteLine(identificate.Id);
                }
            }
        }
    }
}
