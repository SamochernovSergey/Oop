using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class List<T> : IList<T>
    {
        private T[] array;
        private int version;

        public List()
        {
            array = new T[10];
        }

        public List(T[] array)
        {
            this.array = new T[array.Length + 5];
            Array.Copy(array, this.array, array.Length);
            Count = array.Length;
        }

        public List(int capacity)
        {
            array = new T[capacity];
        }

        public int Capacity
        {
            get
            {
                return array.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("Capacity < Count");
                }

                if (value == array.Length)
                {
                    return;
                }

                Array.Resize(ref array, value);
            }
        }

        private void IncreaseCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }

        private void EnsureCapacity()
        {
            if (Count >= array.Length)
            {
                IncreaseCapacity();
            }
        }

        public void TrimExcess()
        {
            if (Capacity * 0.9 > Count)
            {
                Array.Resize(ref array, Count);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Argument Out Of Range");
                }

                return array[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Argument Out Of Range");
                }

                array[index] = value;
                ++version;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly => false;

        public void Add(T obj)
        {
            EnsureCapacity();
            array[Count] = obj;
            ++Count;
            ++version;
        }

        public void Clear()
        {
            if (Count > 0)
            {
                array = new T[10];
                Count = 0;
                ++version;
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The size of the data is larger than the array Count");
            }

            int j = arrayIndex;

            for (int i = 0; i < Count; i++)
            {
                array[j] = this.array[i];
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int trueVersion = version;

            for (int i = 0; i < Count; i++)
            {
                if (trueVersion != version)
                {
                    throw new InvalidOperationException("don't change collection when Enumirator is working!!!");
                }

                yield return array[i];                
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(array[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }

            EnsureCapacity();
            Array.Copy(array, index, array, index + 1, Count - index);
            array[index] = item;
            ++Count;
            ++version;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }

            Array.Copy(array, index + 1, array, index, Count - index - 1);
            --Count;
            ++version;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                stringBuilder.Append(array[i]).AppendLine("; ");
            }

            stringBuilder.Append("Count = ").Append(Count).AppendLine();
            stringBuilder.Append("Capacity = ").Append(Capacity);

            return stringBuilder.ToString();
        }
    }
}