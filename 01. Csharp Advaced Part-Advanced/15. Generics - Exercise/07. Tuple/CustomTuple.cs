using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    public class CustomTuple<T1, T2>
    {
        private readonly T1 item1;
        private readonly T2 item2;

        public CustomTuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
