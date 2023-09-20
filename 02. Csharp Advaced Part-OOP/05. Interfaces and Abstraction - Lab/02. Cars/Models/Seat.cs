using Cars.Models.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public string Start() => $"Engine start{Environment.NewLine}";

        public string Stop() => $"Breaaak!{Environment.NewLine}";

        public override string ToString()
            => $"{Color} Seat {Model}{Environment.NewLine}{Start()}{Stop()}".Trim();
    }
}
