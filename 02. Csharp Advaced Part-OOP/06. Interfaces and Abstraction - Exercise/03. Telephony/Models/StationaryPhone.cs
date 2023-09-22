using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interface;

namespace Telephony.Models
{
    public class StationaryPhone : ICalling
    {
        public string Call(string number)
        {

            if (number.Any(x => char.IsDigit(x) == false))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }
    }
}
