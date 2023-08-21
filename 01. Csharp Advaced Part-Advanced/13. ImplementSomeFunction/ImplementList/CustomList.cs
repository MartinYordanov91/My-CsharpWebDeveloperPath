using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList
    {
        private const int initiallyCapacity = 2;
        public CustomList()
        {
            Items = new int[initiallyCapacity];
            Count = 0;
        } 
        public int[] Items { get; set; }
        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                AutOfrangeError(index);
                return Items[index];
            }
            set
            {
                AutOfrangeError(index);
                Items[index] = value;
            }
        }
        public void Add(int item)
        {
            Resize();
            Items[Count++] = item;
        }
        public int RemoveAt(int index)
        {
            AutOfrangeError(index);
            int remulved = Items[index];
            Items[index] = default;
            ShiftLeft(index);
            Count--;
            Items[Count] = default;
            Shrink();
            return remulved;
        }
        public void Reverse()
        {
            int[] copy = new int[Items.Length];
            int num = Count-1;
            for (int i = 0; i < Count; i++)
            {
                copy[i] = Items[num--];
            }
            Items = copy;
        }
        public void InsertAt(int index, int item)
        {
            AutOfrangeError(index);
            Resize();
            ShiftRight(index);
            Items[index] = item;
            Count++;
        }
        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            AutOfrangeError(firstIndex);
            AutOfrangeError(secondIndex);

            int firstElement = Items[firstIndex];
            Items[firstIndex] = Items[secondIndex];
            Items[secondIndex] = firstElement;
        }
        private void Shrink()
        {
            if (Count <= Items.Length / 4)
            {
                int[] copy = new int[Items.Length / 2];
                for (int i = 0; i < Count; i++)
                {
                    copy[i] = Items[i];
                }

                Items = copy;
            }
        }
        private void ShiftRight(int index)
        {
            for (int i = Count - 1; i >= index; i--)
            {
                Items[i + 1] = Items[i];
            }
        }
        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                Items[i] = Items[i + 1];
            }
        }
        private void AutOfrangeError(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Пич Излезнал си от ренджа на масива");
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
