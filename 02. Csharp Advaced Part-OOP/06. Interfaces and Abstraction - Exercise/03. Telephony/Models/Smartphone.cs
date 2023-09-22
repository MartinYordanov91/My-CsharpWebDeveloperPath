using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interface;

namespace Telephony.Models
{
    public class Smartphone : ICalling, IBrowsing
    {
        public string Call(string number)
        {
            if (number.Any(x => char.IsDigit(x) == false))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }
        public string Browse(string web)

        {
            if (web.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {web}!";
        }
    }
}
