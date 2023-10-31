using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double initialRating = 4;
        private const double increaseRating = 1;
        private const double decreaseRating = 1;

        public CenterBack(string name) 
            : base(name, initialRating)
        {
        }

        public override void DecreaseRating()
        {
            this.Rating -= decreaseRating;
            if (this.Rating < 1)
            {
                this.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            this.Rating += increaseRating;
            if (this.Rating > 10)
            {
                this.Rating = 10;
            }
        }
    }
}
