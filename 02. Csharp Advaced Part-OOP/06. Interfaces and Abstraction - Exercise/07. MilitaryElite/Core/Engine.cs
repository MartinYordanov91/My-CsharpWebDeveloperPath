
namespace MilitaryElite.Core
{
    using MilitaryElite.Core.Interface;
    using MilitaryElite.Enums;
    using MilitaryElite.Models;
    using MilitaryElite.Models.Interface;
    using System;
    public class Engine : IEngine
    {
        private Dictionary<int, ISoldier> soldiers;
        public Engine()
        {
            soldiers = new();
        }
        public void Run()
        {
            string intText = string.Empty;
            while ((intText = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = intText
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(ProcessInput(tokens));
                }
                catch (Exception) { }
            }
        }
        private string ProcessInput(string[] tokens)
        {
            ISoldier soldier = null;

            string soldierType = tokens[0];
            int soldierId = int.Parse(tokens[1]);
            string firstName = tokens[2];
            string lastName = tokens[3];

            switch (soldierType)
            {
                case "Private":
                    soldier = GetPrivate(soldierId, firstName, lastName, decimal.Parse(tokens[4]));
                    break;
                case "LieutenantGeneral":
                    soldier = GetLeutenantGeneral(soldierId, firstName, lastName, decimal.Parse(tokens[4]), tokens);
                    break;
                case "Engineer":
                    soldier = GetEngineer(soldierId, firstName, lastName, decimal.Parse(tokens[4]), tokens);
                    break;
                case "Commando":
                    soldier = GetCommando(soldierId, firstName, lastName, decimal.Parse(tokens[4]), tokens);
                    break;
                case "Spy":
                    soldier = GetSpy(soldierId, firstName, lastName, int.Parse(tokens[4]));
                    break;

            }


            soldiers.Add(soldierId, soldier);
            return soldier.ToString();
        }

        private ISoldier GetPrivate(int id, string firstname, string lastname, decimal salary)
        => new Private(id, firstname, lastname, salary);
        private ISoldier GetLeutenantGeneral(int id, string firstname, string lastname, decimal salary, string[] tokens)
        {
            List<IPrivate> curent = new();

            for (int i = 5; i < tokens.Length; i++)
            {
                int idd = int.Parse(tokens[i]);
                IPrivate privatess = (IPrivate)soldiers[idd];
                curent.Add(privatess);
            }

            return new LieutenantGeneral(id, firstname, lastname, salary, curent);
        }
        private ISoldier GetEngineer(int id, string firstname, string lastname, decimal salary, string[] tokens)
        {
            bool isValide = Enum.TryParse(tokens[5], out Corps corps);

            if (!isValide) { throw new ArgumentException(); }

            List<IRepair> repairs = new();
            for (int i = 6; i < tokens.Length; i += 2)
            {
                IRepair repair = new Repair(tokens[i], int.Parse(tokens[i + 1]));
                repairs.Add(repair);
            }

            return new Engineer(id, firstname, lastname, salary, corps, repairs);
        }
        private ISoldier GetCommando(int id, string firstname, string lastname, decimal salary, string[] tokens)
        {
            bool isValide = Enum.TryParse<Corps>(tokens[5], out Corps corps);

            if (!isValide) { throw new ArgumentException(); }

            List<IMissions> missions = new();
            for (int i = 6; i < tokens.Length; i += 2)
            {
                bool isMisions = Enum.TryParse(tokens[i + 1], out State state);

                if (!isMisions)
                {
                    continue;
                }

                IMissions missio = new Mission(tokens[i], state);
                missions.Add(missio);
            }

            return new Commando(id, firstname, lastname, salary, corps, missions);
        }
        private ISoldier GetSpy(int id, string firstname, string lastname, int codeNumber)
            => new Spy(id, firstname, lastname, codeNumber);
    }
}
