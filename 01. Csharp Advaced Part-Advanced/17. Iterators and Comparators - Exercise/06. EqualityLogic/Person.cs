using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjects
{
    public class Person: IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
           
        }

        public string Name { get; set; }
        public int Age { get; set; }


        public int CompareTo(Person other)
        {
            if(Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }

            return Age.CompareTo(other.Age);
        }

        public override bool Equals(object? obj)
        {
           Person person = obj as Person;

           if(person == null) return false;

           return Name.Equals(person.Name) && Age.Equals(person.Age);
        }

        public override int GetHashCode()
        {
            int hashCode = Name.GetHashCode() + Age.GetHashCode();
            return hashCode;
        }
    }
}
