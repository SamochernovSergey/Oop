using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class List<T> : IList<T>
    {
        private T[] array;
        private int length;
        private int version;

        public List()
        {
            array = new T[10];
        }

        public List(T[] array)
        {
            this.array = new T[array.Length + 5];
            Array.Copy(array, this.array, array.Length);
            length = array.Length;
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
                if (value < length)
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
            if (length >= array.Length)
            {
                IncreaseCapacity();
            }
        }

        public void TrimExcess()
        {
            if (Capacity * 0.9 > length)
            {
                Array.Resize(ref array, length);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException("Argument Out Of Range");
                }
                return array[index];
            }

            set
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException("Argument Out Of Range");
                }

                array[index] = value;
                ++version;
            }
        }

        public int Count
        {
            get
            {
                return length;
            }
        }

        public bool IsReadOnly => false;

        public void Add(T obj)
        {
            EnsureCapacity();
            array[length] = obj;
            ++length;
            ++version;
        }

        public void Clear()
        {
            if (length > 0)
            {
                array = new T[10];
                length = 0;
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

            if (length > array.Length - arrayIndex)
            {
                throw new ArgumentException("The size of the data is larger than the array Count");
            }

            int j = arrayIndex;
            for (int i = 0; i < length; i++)
            {
                array[j] = this.array[i];
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int trueVersion = version;
            for (int i = 0; i < length; i++)
            {
                yield return array[i];
                if (trueVersion != version)
                {
                    throw new InvalidOperationException("don't change collection when Enumirator is working!!!");
                }
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < length; i++)
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
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }

            EnsureCapacity();
            Array.Copy(array, index, array, index + 1, length - index + 1);
            array[index] = item;
            ++length;
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
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }

            Array.Copy(array, index + 1, array, index, length - index - 1);
            --length;
            ++version;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(array[i]).Append(";").AppendLine();
            }

            stringBuilder.Append("Count = ").Append(Count).AppendLine();
            stringBuilder.Append("Capacity = ").Append(Capacity);

            return stringBuilder.ToString();
        }
    }
}