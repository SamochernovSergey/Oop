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

        public int Count
        {
            get;
            private set;
        }

        public T GetFirstElement()
        {
            if (head == null)
            {
                throw new NullReferenceException("List is empty");
            }
            return head.Data;
        }

        private ListItem<T> GetItemByIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }
            else if (index == 0)
            {
                return head;
            }

            int i = 1;
            ListItem<T> p;
            for (p = head.Next; p != null; p = p.Next, i++)
            {
                if (index == i)
                {
                    break;
                }
            }
            return p;
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
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }
            T oldData;
            if (index == 0)
            {
                oldData = head.Data;
                RemoveBegin();
            }
            else
            {
                ListItem<T> p = GetItemByIndex(index - 1);
                oldData = p.Next.Data;
                p.Next = p.Next.Next;
                Count--;
            }
            return oldData;            
        }

        public void InsertBegin(T data)
        {
            head = new ListItem<T>(data, head);
            Count++;
        }

        public void InsertByIndex(T data, int index)
        {
            if (index > Count || index < 0)
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
                Count++;
            }
        }

        public bool RemoveByData(T data)
        {
            if (head == null)
            {
                return false;
            }
            if (object.Equals(head.Data, data))
            {
                head = head.Next;
                Count--;
                return true;
            }
            for (ListItem<T> p = head.Next; p.Next != null; p = p.Next)
            {
                if (object.Equals(p.Next.Data, data))
                {
                    p.Next = p.Next.Next;
                    Count--;
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
            Count--;
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
            if (head == null)
            {
                return;
            }

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

            ListItem<T> newItem = new ListItem<T>(head.Data);
            copy.head = newItem;

            for (ListItem<T> p = head; p.Next != null; p = p.Next, newItem = newItem.Next)
            {
                newItem.Next = new ListItem<T>(p.Next.Data);
            }

            copy.Count = Count;
            return copy;
        }
    }
}