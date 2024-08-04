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

    }
}
