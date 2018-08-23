﻿using System;
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
            if (index < 1 || index >= Count)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }
            else if (index == 1)
            {
                return head;
            }
            else
            {
                int i = 2;
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
            if (index < 1 || index > Count)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }
            if (index == 1)
            {
                RemoveBegin();
            }

            ListItem<T> p = GetItemByIndex(index - 1);
            T oldData = p.Next.Data;
            p.Next = p.Next.Next;
            Count--;
            return oldData;

        }

        public void InsertBegin(T data)
        {
            head = new ListItem<T>(data, head);
            Count++;
        }

        public void InsertByIndex(T data, int index)
        {
            if (index > Count || index < 1)
            {
                throw new IndexOutOfRangeException("Argument Out Of Range");
            }
            else if (index == 1)
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
            if (Object.Equals(head.Data, data))
            {
                head = head.Next;
                Count--;
                return true;
            }
            for (ListItem<T> p = head.Next; p.Next != null; p = p.Next)
            {
                if (Object.Equals(p.Next.Data, data))
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

            ListItem<T> newItem = new ListItem<T>(head.Data, head.Next);
            copy.head = newItem;

            for (ListItem<T> p = head; p.Next != null; p = p.Next, newItem = newItem.Next)
            {
                newItem.Next = new ListItem<T>(p.Next.Data, p);
            }

            newItem.Next = null;
            copy.Count = Count;
            return copy;
        }
    }
}