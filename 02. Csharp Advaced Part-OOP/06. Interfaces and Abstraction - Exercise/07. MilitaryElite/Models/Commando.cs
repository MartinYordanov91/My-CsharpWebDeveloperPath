namespace MilitaryElite.Models
{
    using Interface;
    using MilitaryElite.Enums;
    using System.Collections.Generic;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps crops, IReadOnlyCollection<IMissions> missions)
            : base(id, firstName, lastName, salary, crops)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMissions> Missions { get; private set; }

        public override string ToString()
           => $"{base.ToString()}{Environment.NewLine}Missions:{Environment.NewLine}  {string.Join(Environment.NewLine + "  ", Missions)}".TrimEnd();
    }
}
