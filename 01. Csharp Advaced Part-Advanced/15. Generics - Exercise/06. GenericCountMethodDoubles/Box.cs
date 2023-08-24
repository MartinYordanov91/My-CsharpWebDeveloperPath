using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable<T>
    {
        List<T> items = new List<T>();  

        public void Add(T item)
        {
            items.Add(item);
        }

        public int Count(T text)
        {
            int count = 0;
            foreach (var item in items)
            {
                if (item.CompareTo(text) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
