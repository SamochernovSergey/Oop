using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Tree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public int Count
        {
            get;
            private set;
        }

        public Tree()
        {

        }

        public Tree(T item)
        {
            root = new TreeNode<T>(item);
        }

        public void Insert(T item)
        {
            if (root == null)
            {
                root = new TreeNode<T>(item);
                ++Count;
                return;
            }

            TreeNode<T> node = root;

            while (true)
            {
                if (item.CompareTo(node.Data) < 0)
                {
                    if (node.left != null)
                    {
                        node = node.left;
                        continue;
                    }
                    else
                    {
                        node.left = new TreeNode<T>(item);
                        ++Count;
                        break;
                    }
                }
                else
                {
                    if (node.right != null)
                    {
                        node = node.right;
                        continue;
                    }
                    else
                    {
                        node.right = new TreeNode<T>(item);
                        ++Count;
                        break;
                    }
                }
            }
        }

        public bool Contains(T item)
        {
            if (root == null)
            {
                return false;
            }

            TreeNode<T> node = root;

            while (true || false)
            {
                if (node.Data.CompareTo(item) == 0)
                {
                    return true;
                }
                else if (node.Data.CompareTo(item) > 0)
                {
                    if (node.left != null)
                    {
                        node = node.left;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (node.right != null)
                    {
                        node = node.right;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public string Properties(T item)
        {
            if (root == null)
            {
                return "Узел не найден";
            }

            TreeNode<T> node = root;

            if (node.Data.CompareTo(item) == 0)
            {
                return "Корень";
            }

            while (true)
            {
                if (node.Data.CompareTo(item) == 0)
                {
                    if (node.left != null && node.right != null)
                    {
                        return "Узел с двумя детьми";
                    }
                    else if (node.left != null)
                    {
                        return "Узел с одним ребёнком(левый)";
                    }
                    else if (node.right != null)
                    {
                        return "Узел с одним ребёнком(правый)";
                    }
                    else
                    {
                        return "Лист";
                    }
                }
                else if (node.Data.CompareTo(item) > 0)
                {
                    if (node.left != null)
                    {
                        node = node.left;
                    }
                    else
                    {
                        return "Узел не найден";
                    }
                }
                else
                {
                    if (node.right != null)
                    {
                        node = node.right;
                    }
                    else
                    {
                        return "Узел не найден";
                    }
                }

            }
        }

        public bool Delete(T item)
        {
            if (root == null)
            {
                return false;
            }

            TreeNode<T> node = root;
            TreeNode<T> parent = node;
            TreeNode<T> minLeft;

            if (root.Data.CompareTo(item) == 0)
            {
                if (node.right != null && node.left != null)
                {
                    if (node.right.left != null)
                    {
                        node = node.right;

                        while (node.left != null)
                        {
                            parent = node;
                            node = node.left;

                            if (node.left == null)
                            {
                                minLeft = node;
                                parent.left = node.right;
                                minLeft.left = root.left;
                                minLeft.right = root.right;
                                root = minLeft;
                                --Count;
                                return true;
                            }
                            /*if (node.left == null && node.right == null)
                            {
                                minLeft = node;
                                parent.left = null;
                                minLeft.left = root.left;
                                minLeft.right = root.right;
                                root = minLeft;
                                --Count;
                                return true;
                            }*/
                        }
                    }
                    else
                    {
                        root.right.left = root.left;
                        root = root.right;
                        --Count;
                        return true;
                    }
                }
            }
            while (true)
            {
                bool left = false;
                bool right = false;
                if (node.Data.CompareTo(item) > 0)
                {
                    if (node.left != null)
                    {
                        parent = node;
                        node = node.left;
                        if (node.Data.CompareTo(item) == 0)
                        {
                            left = true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (node.Data.CompareTo(item) < 0)
                {
                    if (node.right != null)
                    {
                        parent = node;
                        node = node.right;
                        if (node.Data.CompareTo(item) == 0)
                        {
                            right = true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                if (node.Data.CompareTo(item) == 0)
                {
                    if (node.left != null && node.right != null)
                    {
                        if (node.right.left != null)
                        {
                            node = node.right;

                            while (node.left != null)
                            {
                                minLeft = node;
                                node = node.left;

                                if (node.left == null)
                                {
                                    minLeft.left = node.right;

                                    if (left == true)
                                    {
                                        node.left = parent.left.left;
                                        node.right = parent.left.right;
                                        parent.left = node;
                                    }
                                    if (right == true)
                                    {
                                        node.left = parent.right.left;
                                        node.right = parent.right.right;
                                        parent.right = node;
                                    }
                                    --Count;
                                    return true;
                                }
                                /*if (node.left == null && node.right == null)
                                {
                                    if (left == true)
                                    {
                                        node.left = parent.left.left;
                                        node.right = parent.left.right;
                                        parent.left = node;
                                    }
                                    if (right == true)
                                    {
                                        node.left = parent.right.left;
                                        node.right = parent.right.right;
                                        parent.right = node;
                                    }
                                    --Count;
                                    return true;
                                }*/
                            }
                        }
                        else
                        {
                            if(left == true)
                            {
                                node.right.left = node.left;
                                parent.left = node.right;
                            }
                            if (right == true)
                            {
                                node.right.left = node.left;
                                parent.right = node.right;
                            }

                                --Count;
                            return true;
                        }
                    }
                    else if (node.left != null)
                    {
                        if (left == true)
                        {
                            parent.left = node.left;
                        }
                        if (right == true)
                        {
                            parent.right = node.left;
                        }

                        --Count;
                        return true;

                    }
                    else if (node.right != null)
                    {
                        if (left == true)
                        {
                            parent.left = node.right;
                        }
                        if (right == true)
                        {
                            parent.right = node.right;
                        }

                        --Count;
                        return true;

                    }
                    else
                    {
                        if (left == true)
                        {
                            parent.left = null;
                        }
                        if (right == true)
                        {
                            parent.right = null;
                        }
                        --Count;
                        return true;

                    }
                }
            }
        }
    }
}