using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
     public class Person
    {
        //field
        private string name;
        private int age;
      
        
        //constructor
        public Person()
        {
            Name = "No name";
            Age = 1;
        }
        public Person( int age)
        : this()
        {
            Age = age;
        }
        public Person(string name, int age)
        : this(age)
        {
            Name = name;
        }

        //properties
        public string Name { get { return name; } set { name = value; } }

        public int Age { get {return age; } set {age = value; } }
        //method

    }
}
