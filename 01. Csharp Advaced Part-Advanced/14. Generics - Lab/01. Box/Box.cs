using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            List = new List<T>();
            Count = 0;
        }

        public List<T> List { get; set; }
        public int Count { get; private set; }

        public void Add(T elements)
        {
            List.Add(elements);
            Count++;
        }
        public T Remove()
        {
            T topElement = List[Count - 1];
            List.RemoveAt(Count - 1);
            Count--;
            return topElement;
        }
    }
}
