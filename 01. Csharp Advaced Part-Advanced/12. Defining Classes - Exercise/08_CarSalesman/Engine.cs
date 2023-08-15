using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, int power, int displacement)
        : this(model, power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
        : this(model, power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
         : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");
            string ddisplacement = Displacement != 0 ? Displacement.ToString() : "n/a";
            sb.AppendLine($"    Displacement: {ddisplacement}");
            string eefficiency = Efficiency != null ? Efficiency : "n/a";
            sb.Append($"    Efficiency: {eefficiency}");
            return sb.ToString();
        }
    }
}
