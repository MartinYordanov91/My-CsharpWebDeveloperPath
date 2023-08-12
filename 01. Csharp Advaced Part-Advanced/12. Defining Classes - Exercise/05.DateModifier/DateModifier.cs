using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static int GetDifferenceInDays(string start, string end)
        {
            DateTime startDay = DateTime.Parse(start);
            DateTime endDay = DateTime.Parse(end);

            TimeSpan different = endDay - startDay;

            return Math.Abs(different.Days);
        }
    }
}
