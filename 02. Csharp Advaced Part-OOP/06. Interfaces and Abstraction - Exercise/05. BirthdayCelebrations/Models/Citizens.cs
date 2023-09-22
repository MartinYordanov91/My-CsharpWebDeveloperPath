using BirthdayCelebrations.Models.Interface;
using BirthdayCelebrationsrol.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrationsrol.Models
{
    internal class Citizens : IIdentification , IBirthdates
    {
        public Citizens(string name, int age, string id, string birthdates)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdates = birthdates;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdates { get; private set; }
    }
}
