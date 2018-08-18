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

        public int Length
        {
            get
            {
                return length;
            }
        }

        public T GetFirstElement()
        {
            return head.Data;
        }

        private ListItem<T> GetItemByIndex(int index)
        {
            if (index < 0 || index > length - 1)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }
            else if (index == 0)
            {
                return head;
            }
            else
            {
                int i = 1;
                ListItem<T> p = null;
                for (p = head.Next; p != null; p = p.Next, i++)
                {
                    if (index == i)
                    {
                        break;
                    }
                }
                return p;
            }
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
        }

        public T RemoveByIndex(int index)
        {
            if (index == 0)
            {
                RemoveBegin();
            }

            ListItem<T> p = GetItemByIndex(index - 1);

            if (p.Next == null || index < 0)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }

            T oldData = p.Next.Data;

            if (p.Next.Next == null)
            {
                p.Next = null;
                length--;
                return oldData;
            }
            else
            {
                p.Next = p.Next.Next;
                length--;
                return oldData;
            }

            throw new IndexOutOfRangeException("Argument Out Of Range");
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
                throw new IndexOutOfRangeException("Argument Out Of Range");
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
            if (head.Data.Equals(data))
            {
                head = head.Next;
                length--;
                return true;
            }
            for (ListItem<T> p = head.Next; p.Next != null; p = p.Next)
            {
                if (p.Next.Data.Equals(data))
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
            if (head == null)
            {
                throw new NullReferenceException("List is empty");
            }
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

            if (head == null)
            {
                return copy;
            }
            ListItem<T> newItem = new ListItem<T>(head.Data, head.Next);
            copy.head = newItem;
            for (ListItem<T> p = head; p.Next != null; p = p.Next, newItem = newItem.Next)
            {
                newItem.Next = new ListItem<T>(p.Next.Data, p);
            }
            newItem.Next = null;
            copy.length = length;
            return copy;
        }
    }
}