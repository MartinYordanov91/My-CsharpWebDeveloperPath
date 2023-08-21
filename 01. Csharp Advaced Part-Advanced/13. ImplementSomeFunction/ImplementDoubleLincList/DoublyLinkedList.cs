using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList
    {
        public DoublyLinkedList()
        {
            Count = 0;
        }

        public Nodes Head { get; set; }
        public Nodes Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(int number)
        {
            Nodes newNode = new Nodes(number);

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }
            Count++;
        }

        public void AddLast(int number)
        {
            Nodes newNode = new Nodes(number);
            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
            Count++;
        }
        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int firstElement = Head.Value;
            Head = Head.Next;

            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }
            Count--;
            return firstElement;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            int lastElement = Tail.Value;
            Tail = Tail.Previous;

            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }
            Count--;
            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            Nodes note = Head;
            while (note != null)
            {
                action(note.Value);
                note = note.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;

            Nodes note = Head;
            while (note != null)
            {
                array[index++] = note.Value;
                note = note.Next;
            }

            return array;
        }
    }
}
