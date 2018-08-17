using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        private int length = 0;

        public int GetLength()
        {
            return length;
        } 

        public T GetFirstElement()
        {
            return head.Data;
        }

        private ListItem<T> GetItemByIndex(int index)
        {
            int i = 0;
            for (ListItem<T> p = head; p != null; p = p.Next, i++)
            {
                if (i == index)
                {
                    return p;
                }
            }
            throw new ArgumentOutOfRangeException("ArgumentOutOfRange");
        }

        public T GetDataByIndex(int index)
        {
            return GetItemByIndex(index).Data;
        }

        public T SetDataByIndex(T data, int index)
        {
            ListItem<T> p = GetItemByIndex(index);
            T oldValue = p.Data;
            p.Data = data;
            return oldValue;            
            throw new ArgumentOutOfRangeException("ArgumentOutOfRange");
        }

        public T RemoveByIndex(int index)
        {
            if (index == 0)
            {
                RemoveBegin();
            }
            else if(GetItemByIndex(index).Next == null)
            {
                T oldData = GetDataByIndex(index);
                ListItem<T> p = GetItemByIndex(index - 1);
                p.Next = null;
                length--;
                return oldData;
            }
            else
            {
                T oldData = GetDataByIndex(index);
                ListItem<T> p = GetItemByIndex(index - 1);
                p.Next = GetItemByIndex(index + 1);
                length--;
                return oldData;
            }
            /* int i = 0;
             for (ListItem<T> p = head, prev = null; p != null; prev = p, p = p.Next, i++)
             {
                 if (i == index)
                 {
                     prev.Next = p.Next;
                     Length--;
                     return p.Data;
                 }
             }*/
            throw new ArgumentOutOfRangeException("ArgumentOutOfRange");
        }

        public void InsertBegin(T data)
        {
            head = new ListItem<T>(data, head);
            length++;
        }

        public void InsertByIndex(T data, int index)
        {
            if (index > length)
            {
                throw new ArgumentOutOfRangeException("ArgumentOutOfRange");
            }
            else if (index == 0)
            {
                InsertBegin(data);
            }
            else
            {
                ListItem<T> newItem = GetItemByIndex(index - 1);
                newItem.Next = new ListItem<T>(data, newItem.Next);
                length++;
            }
        }

        public bool RemoveByData(T data)
        {
            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                if (head.Data.Equals(data))
                {
                    head = head.Next;
                    length--;
                    return true;
                }
                else if (p.Next != null && p.Next.Data.Equals(data))
                {
                    p.Next = p.Next.Next;
                    length--;
                    return true;
                }
            }
            return false;
        }

        public T RemoveBegin()
        {
            ListItem<T> p = head;
            head = head.Next;
            length--;
            return p.Data;
        }

        public void PrintList()
        {
            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                Console.WriteLine(p);
            }
        }

        public void Reverse()
        {
            ListItem<T> newItem = null;
            for (ListItem<T> p = head.Next; p != null; p = p.Next)
            {
                head.Next = newItem;
                newItem = head;
                head = p;
            }
            head.Next = newItem;
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> copy = new SinglyLinkedList<T>();

            if (head != null)
            {
                ListItem<T> p = head;
                ListItem<T> newItem = new ListItem<T>(p.Data, p.Next);
                copy.head = newItem;
                for (p = head; p.Next != null; p = p.Next, newItem = newItem.Next)
                {
                    newItem.Next = new ListItem<T>(p.Next.Data, p);
                }
                newItem.Next = null;
                copy.length = length;
                return copy;
            }
            else
            {
                return copy;
            }
        }
    }
}