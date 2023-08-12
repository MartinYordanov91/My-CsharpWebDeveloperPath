using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> famili;

        public Family()
        {
            Famili = new List<Person>();
        }

        List<Person> Famili { get { return famili; } set { famili = value; } }

        public void AddMember(Person person)
        {
            Famili.Add(person); 
        }
        public Person GetOldestMember()
        {
            return famili.OrderByDescending(x =>x.Age).First();
        }
    }
}
