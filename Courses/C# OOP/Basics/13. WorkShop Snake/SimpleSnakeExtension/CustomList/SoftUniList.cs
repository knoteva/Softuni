using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class SoftUniList<T> : IEnumerable
    {
        private const int initialCapacity = 2;

        private T[] array;

        public SoftUniList()
        {
            this.array = new T[initialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.array.Length)
            {
                this.Resize();
            }

            this.array[this.Count++] = item;
        }

        public void Remove(T item)
        {
            //1000
            //200 TODO later
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    this.array[i] = default(T);
                    this.Count--;
                    this.Shrink(i);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        public T this[int number]
        {
            get
            {
                if (number >= 0 && number < this.Count)
                {
                    return this.array[number];
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (number >= 0 && number < this.Count)
                {
                    this.array[number] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        private void Shrink(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }

        private void Resize()
        {
            T[] newArray = new T[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = array[i];
            }

            this.array = newArray;
        }
    }
}
