using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int zetoIndex = 0;
        private List<T> elements = new();
        public int Count { get { return elements.Count; } }
        public void Push(T element)
        {
            elements.Insert(zetoIndex, element);
        }
        public T Pop()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            T remolvElement = elements[zetoIndex];
            elements.RemoveAt(zetoIndex);
            return remolvElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()=>this.GetEnumerator();
        
    }
}
