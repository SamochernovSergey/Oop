using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] table;
        private int version;

        public HashTable()
        {
            table = new List<T>[50];
        }

        public HashTable(int capacity)
        {
            if(capacity <= 0)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }

            table = new List<T>[capacity];
        }

        private int GetHashIndex(T item)
        {
            if (item == null)
            {
                return Capacity - 1;
            }
            return Math.Abs(item.GetHashCode() % table.Length - 1);
        }

        public int Capacity
        {
            get
            {
                return table.Length;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            int index = GetHashIndex(item);

            if (table[index] == null)
            {
                table[index] = new List<T>();
            }

            table[index].Add(item);
            ++Count;
            ++version;
        }

        public void Clear()
        {
            if (Count != 0)
            {
                table = new List<T>[Capacity];
                Count = 0;
                ++version;
            }
        }

        public bool Contains(T item)
        {
            int index = GetHashIndex(item);

            if (table[index] == null)
            {
                return false;
            }

            return table[index].Contains(item);
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

            foreach (T e in this)
            {
                array[arrayIndex] = e;
                arrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int trueVersion = version;

            foreach(List<T> list in table)
            {
                if (list != null)
                {
                    foreach(T e in list)
                    {
                        if (trueVersion != version)
                        {
                            throw new InvalidOperationException("don't change collection when Enumirator is working!!!");
                        }

                        yield return e;
                    }
                }
            }
        }

        public bool Remove(T item)
        {
            int index = GetHashIndex(item);

            if (table[index] == null)
            {
                return false;
            }

            if (table[index].Contains(item))
            {
                table[index].Remove(item);
                --Count;
                ++version;

                if (table[index].Count() == 0)
                {
                    table[index] = null;
                }

                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < table.Length; i++)
            {
                stringBuilder.Append("array[").AppendFormat("{0:d2}", i).Append("] = ");

                if (table[i] == null)
                {
                    stringBuilder.AppendLine("Empty; ");
                }
                else
                {
                    for (int j = 0; j < table[i].Count; j++)
                    {
                        if (table[i].ElementAt(j) == null)
                        {
                            stringBuilder.Append("null");
                        }
                        stringBuilder.Append((table[i].ElementAt(j))).Append(", ");
                    }

                    stringBuilder.Remove(stringBuilder.Length - 2, 2).AppendLine("; ");                   
                }
            }

            stringBuilder.AppendLine().AppendLine("Count = " + Count).AppendLine("Capacity = " + Capacity);           

            return stringBuilder.ToString();
        }
    }
}