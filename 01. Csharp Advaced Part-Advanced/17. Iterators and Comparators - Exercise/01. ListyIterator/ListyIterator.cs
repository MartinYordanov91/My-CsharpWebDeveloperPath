using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private int index = 0;
        private List<T> elements;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
        }
        public bool Move()
        {

            if (index + 1 < elements.Count)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext() => this.index < this.elements.Count - 1;
        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(elements[index]);
        }
    }
}
