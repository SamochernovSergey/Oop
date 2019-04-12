using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class TreeNode<T>
    {
        public TreeNode<T> left;

        public TreeNode<T> right;

        public T Data;      

        public TreeNode(T data)
        {
            Data = data;           
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}