using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Nodes
    {
        public Nodes(int value, Nodes next = null, Nodes previous= null)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }

        public int Value { get; set; }
        public Nodes Next  { get; set; }
        public Nodes Previous  { get; set; }

        public override string ToString()
        {
            return $"{Previous?.Value} <--> {Value} <--> {Next?.Value}";
        }
    }
}
