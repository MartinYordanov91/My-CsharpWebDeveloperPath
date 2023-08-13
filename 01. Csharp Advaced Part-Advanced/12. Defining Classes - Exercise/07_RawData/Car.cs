using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Car
    {
        public Car(
            string model, 
            int speed,
            int power,
            int weight,
            string type,
            double pressure1,
            int age1,
            double pressure2,
            int age2,
            double pressure3,
            int age3,
            double pressure4,
            int age4
            )
        {
            Model = model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(weight, type);
            Tires = new Tires[4];
            Tires[0] = new Tires(pressure1 , age1);
            Tires[1] = new Tires(pressure2 , age2);
            Tires[2] = new Tires(pressure3 , age3);
            Tires[3] = new Tires(pressure4 , age4);
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tires[] Tires { get; set; }

        public override string ToString()
        {
            return Model;
        }
    }
}
