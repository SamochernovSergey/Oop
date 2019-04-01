using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    class List<T> : IList<T>
    {
        private T[] array = new T[10];

        private int length;

        public List()
        {             
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

                T[] array = this.array;
                this.array = new T[value];
                Array.Copy(array, this.array, length);                                
            }
        }

        private void IncreaseCapacity()
        {
            T[] old = array;
            array = new T[old.Length * 2];
            Array.Copy(old, 0, array, 0, old.Length);
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
            if (Capacity * 0.1 > length)
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
            }
        }

        public int Count
        {
            get
            {
                return length;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T obj)
        {
            EnsureCapacity();
            array[length] = obj;
            ++length;
        }

        public void Clear()
        {            
            array = new T[10];
            length = 0;
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }

            return false;
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
            foreach (T e in this.array)
            {
                array[j] = e;
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < length; i++)
            {
                yield return array[i];
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
            ++length;

            for (int i = length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            
            array[index] = item;            
        }

        public bool Remove(T item)
        {
            if (IndexOf(item) != -1)
            {
                RemoveAt(IndexOf(item));
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > length - 1)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }

            Array.Copy(array, index + 1, array, index, length - index - 1);
            --length;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                stringBuilder.Append(array[i]).Append(";").Append(Environment.NewLine);                
            }

            stringBuilder.Append("Count = ").Append(Count).Append(Environment.NewLine);
            stringBuilder.Append("Capacity = ").Append(Capacity);

            return stringBuilder.ToString();
        }
    }
}