using BirthdayCelebrationsrol.Models;
using BirthdayCelebrationsrol.Core.Interface;
using BirthdayCelebrationsrol.Models;
using BirthdayCelebrationsrol.Models.Interface;
using BirthdayCelebrations.Models.Interface;
using BirthdayCelebrations.Models;

namespace BirthdayCelebrationsrol.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IBirthdates> society = new List<IBirthdates>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] infoArg = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (infoArg[0] == "Citizen")
                {
                    IBirthdates citizen = new Citizens(infoArg[1], int.Parse(infoArg[2]), infoArg[3], infoArg[4]);
                    society.Add(citizen);
                }
                else if (infoArg[0] == "Pet")
                {
                    IBirthdates pet = new Pets(infoArg[1], infoArg[2]);
                    society.Add(pet);
                }
               
            }
            string lastDigits = Console.ReadLine();

            foreach (var bird in society)
            {
                if(bird.Birthdates.EndsWith(lastDigits))
                {
                    Console.WriteLine(bird.Birthdates);
                }
            }
        }
    }
}
