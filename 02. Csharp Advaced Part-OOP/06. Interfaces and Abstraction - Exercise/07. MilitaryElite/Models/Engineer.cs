namespace MilitaryElite.Models
{
    using Interface;
    using MilitaryElite.Enums;
    using System.Collections.Generic;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps crops, IReadOnlyCollection<IRepair> repairs) : base(id, firstName, lastName, salary, crops)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public override string ToString()
           => $"{base.ToString()}{Environment.NewLine}Repairs:{Environment.NewLine}  {string.Join(Environment.NewLine+"  ", Repairs)}".TrimEnd();
    }
}
