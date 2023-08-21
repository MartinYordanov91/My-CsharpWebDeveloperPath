using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class CustomStack
    {
        private const int startCapacity = 4;
        public CustomStack()
        {
            Items = new int[startCapacity];
            Count = 0;
        }
        public int[] Items { get; set; }
        public int Count { get; private set; }

        public void Push(int Element)
        {
            Resize();
            Items[Count++] = Element;
        }
        public int Pop()
        {
            Exception();
            int lastNum = Items[Count - 1];
            Items[Count - 1] = default;
            Count--;
            Shrink();
            return lastNum;
        }
        public int Peek()
        {
            Exception();
            int lastNum = Items[Count - 1];
            return lastNum;
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(Items[i]);
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
                throw new InvalidOperationException("The Stack colection is Empty");
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
