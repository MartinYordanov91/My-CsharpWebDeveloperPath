using MilitaryElite.Enums;
using MilitaryElite.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps crops)
            : base(id, firstName, lastName, salary)
        {
            Crops = crops;
        }

        public Corps Crops { get; private set; }
        public override string ToString()
           => $"{base.ToString()}{Environment.NewLine}Corps: {Crops}";
    }
}
