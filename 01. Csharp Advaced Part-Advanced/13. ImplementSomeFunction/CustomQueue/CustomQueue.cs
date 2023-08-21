using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class CustomQueue
    {
        private const int startCapacity = 4;
        private const int firstIndex = 0;
        public CustomQueue()
        {
            Items = new int[startCapacity];
            Count = 0;
        }
        public int[] Items { get; set; }
        public int Count { get; private set; }

        public void Enqueue(int element)
        {
            Resize();
            ShiftRight();
            Items[firstIndex] = element;
            Count++;
        }
        public int Dequeue()
        {
            Exception();
            int firstElementIn = Items[Count - 1];
            Items[Count - 1] = default;
            Count--;
            Shrink();
            return firstElementIn;
        }
        public int Peek()
        {
            Exception();
            return Items[Count - 1];
        }
        public int Clear()
        {
            Exception();
            int itemsRemulved = Count;
            Count = 0;
            Items = new int[startCapacity];
            return itemsRemulved;
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(Items[i]);
            }
        }
        private void ShiftRight()
        {
            for (int i = Count; i > 0; i--)
            {
                Items[i] = Items[i - 1];
            }
        }
        private void Shrink()
        {
            if (Count >= startCapacity && Count <= Items.Length / 4)
            {
                int[] copy = new int[Items.Length / 2];
                for (int i = 0; i < Count; i++)
                {
                    copy[i] = Items[i];
                }
                Items = copy;
            }
        }
        private void Exception()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The Queue colection is Empty");
            }
        }
        private void Resize()
        {
            if (Count == Items.Length)
            {
                int[] copy = new int[Items.Length * 2];
                for (int i = 0; i < Count; i++)
                {
                    copy[i] = Items[i];
                }
                Items = copy;
            }
        }
    }
}
