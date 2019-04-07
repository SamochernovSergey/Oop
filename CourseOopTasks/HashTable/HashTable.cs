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
            table = new List<T>[capacity];
        }

        private int GetHashIndex(T item)
        {
            return Math.Abs(item.GetHashCode() % table.Length);
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

            if (table[index].Contains(item))
            {
                return;
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

            for (int i = 0; i < table.Length; i++)
            {                
                if (table[i] != null)
                {
                    for (int j = 0; j < table[i].Count; j++)
                    {                        
                        array[arrayIndex] = table[i].ElementAt(j);
                        arrayIndex++;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int trueVersion = version;

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    for (int j = 0; j < table[i].Count; j++)
                    {
                        if (trueVersion != version)
                        {
                            throw new InvalidOperationException("don't change collection when Enumirator is working!!!");
                        }

                        yield return table[i].ElementAt(j);
                    }
                }
            }
        }

        public bool Remove(T item)
        {
            int index = GetHashIndex(item);

            if (table[index].Contains(item))
            {
                table[index] = null;
                --Count;
                ++version;

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
                stringBuilder.Append("array[").Append(String.Format("{0:d2}", i)).Append("]").Append(" = ");

                if (table[i] == null)
                {
                    stringBuilder.Append("null").AppendLine("; ");
                }
                else
                {
                    for (int j = 0; j < table[i].Count; j++)
                    {
                        stringBuilder.Append((table[i].ElementAt(j))).Append(", ");
                    }

                    stringBuilder.Remove(stringBuilder.Length - 2, 2);
                    stringBuilder.AppendLine("; ");
                }
            }
            stringBuilder.Append("Count = ").Append(Count).AppendLine();
            stringBuilder.Append("Capacity = ").Append(Capacity);

            return stringBuilder.ToString();
        }
    }
}