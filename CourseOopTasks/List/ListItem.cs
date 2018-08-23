using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class ListItem<T>
    {
        public T Data
        {
            get;
            set;
        }

        public ListItem<T> Next
        {
            get;
            set;
        }

        public ListItem(T data)
        {
            this.Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            this.Data = data;
            this.Next = next;
        }

        public override string ToString()
        {
            return string.Format("{0}", Data);
        }
    }
}