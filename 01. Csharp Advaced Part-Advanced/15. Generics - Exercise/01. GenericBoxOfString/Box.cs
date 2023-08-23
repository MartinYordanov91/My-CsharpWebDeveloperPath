using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxОfString
{
    public class Box<T>
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public  override string  ToString()
        {
            string className = typeof(T).FullName;
            return $"{className}: {Value}";
        }
    }
}
