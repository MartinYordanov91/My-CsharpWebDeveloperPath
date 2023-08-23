using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        public Box()
        {
        }
        public Box(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public List<T> Swap(List<T> values, int index1, int index2)
        {
            if (IsInRange(values,index1, index2))
            {
                T firstelement = values[index1];
                values[index1] = values[index2];
                values[index2] = firstelement;
            }
            return values;
        }
        public override string ToString()
        {
            string className = typeof(T).FullName;
            return $"{className}: {Value}";
        }
        private bool IsInRange(List<T> values, int index1, int index2)
        {
            if (values.Count <= index1 ||
                index1 < 0 ||
                values.Count <= index2 ||
                index2 < 0)
            {
                return false;
            }
            return true;
        }
    }
}
