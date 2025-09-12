using System;

namespace TRW.CommonLibraries.Core
{
    public class SearchTree<T> : NodeTree<T> where T : IComparable<T>
    {
        public SearchTree()
            : base()
        {

        }

        public SearchTree(T initialValue)
            : this()
        {
            Root = Insert(initialValue);
        }

        public bool Contains(T value)
        {
            return Contains(Root, value);
        }

        public bool Find(T value, out Node<T> node)
        {
            return Find(Root, value, out node);
        }

        public Node<T> Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(this, value);
                return Root;
            }

            return Insert(Root, value);
        }

        protected Node<T> Insert(Node<T> root, T value)
        {
            if (root == null)
            {
                root = new Node<T>(this, value);
            }
            else if (value < root)
            {
                root.Left = Insert(root.Left, value);
            }
            else if (value > root)
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }

        protected bool Contains(Node<T> root, T value)
        {
            if (root == null)
            {
                return false;
            }
            else if (value < root)
            {
                return Contains(root.Left, value);
            }
            else if (value > root)
            {
                return Contains(root.Right, value);
            }
            else
            {
                return true;
            }
        }

        protected bool Find(Node<T> root, T value, out Node<T> node)
        {
            node = null;
            if (root == null)
            {
                return false;
            }
            else if (value < root)
            {
                return Find(root.Left, value, out node);
            }
            else if (value > root)
            {
                return Find(root.Right, value, out node);
            }
            else
            {
                node = root;
                return true;
            }
        }

        public bool Remove(T value)
        {
            bool removed = false;
            Root = Remove(Root, value, ref removed);
            return removed;
        }

        private Node<T> Remove(Node<T> root, T value, ref bool removed)
        {
            if (root == null)
                return null;

            if (value < root)
            {
                root.Left = Remove(root.Left, value, ref removed);
            }
            else if (value > root)
            {
                root.Right = Remove(root.Right, value, ref removed);
            }
            else
            {
                removed = true;
                // Case 1: No child
                if (root.Left == null && root.Right == null)
                {
                    return null;
                }
                // Case 2: One child
                else if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                // Case 3: Two children
                else
                {
                    // Find the minimum value in the right subtree
                    Node<T> minNode = FindMin(root.Right);
                    root.Data = minNode.Data;
                    root.Right = Remove(root.Right, minNode.Data, ref removed);
                }
            }
            return root;
        }

        private Node<T> FindMin(Node<T> node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

    }
}
