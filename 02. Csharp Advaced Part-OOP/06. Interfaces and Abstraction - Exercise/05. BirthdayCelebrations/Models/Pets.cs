using BirthdayCelebrations.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    internal class Pets : IBirthdates
    {
        public Pets(string name, string birthdates)
        {
            Name = name;
            Birthdates = birthdates;
        }

        public string Name { get; private set; }
        public string Birthdates { get; private set; }
    }
}
