using System;
using System.Collections.Generic;

namespace TRW.CommonLibraries.Core
{
    public class Node<T>:IComparable<T>, IComparable<Node<T>> where T : IComparable<T>
    {
        public Node() { }
        public Node(NodeTree<T> tree)
        {
            Tree = tree;
        }

        public Node(NodeTree<T> tree, T value)
            :this(tree)
        {
            Data = value;
        }

        public NodeTree<T> Tree { get; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public bool Visible { get; set; } = true;

        public T Data { get; set; }

        public TraversalStyles TraversalStyle => Tree == null? TraversalStyles.InOrder: Tree.TraversalStyle;

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }

        public int CompareTo(Node<T> other)
        {
            return Data.CompareTo(other.Data);
        }

        public IEnumerator<T> GetEnumerator()
        {
            switch (TraversalStyle)
            {
                case TraversalStyles.PreOrder:
                    return GetEnumeratorPreOrder();
                case TraversalStyles.InOrder:
                    return GetEnumeratorInOrder();
                case TraversalStyles.PostOrder:
                    return GetEnumeratorPostOrder();
            }
            return null;
        }

        protected IEnumerator<T> GetEnumeratorPreOrder()
        {
            yield return Data;

            if (Left != null && Left.Visible)
            {
                foreach (var v in Left)
                {
                    yield return v;
                }
            }

            if (Right != null && Right.Visible)
            {
                foreach (var v in Right)
                {
                    yield return v;
                }
            }
        }

        protected IEnumerator<T> GetEnumeratorInOrder()
        {
            if (Left != null && Left.Visible)
            {
                foreach (var v in Left)
                {
                    yield return v;
                }
            }

            yield return Data;

            if (Right != null && Right.Visible)
            {
                foreach (var v in Right)
                {
                    yield return v;
                }
            }
        }

        protected IEnumerator<T> GetEnumeratorPostOrder()
        {
            if (Left != null && Left.Visible)
            {
                foreach (var v in Left)
                {
                    yield return v;
                }
            }

            if (Right != null && Right.Visible)
            {
                foreach (var v in Right)
                {
                    yield return v;
                }
            }

            yield return Data;

        }

        public override string ToString()
        {
            return Data.ToString();
        }

        #region Operators
        public static bool operator <(Node<T> left, Node<T> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Node<T> left, Node<T> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Node<T> left, Node<T> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Node<T> left, Node<T> right)
        {
            return left.CompareTo(right) >= 0;
        }
        public static bool operator <(Node<T> left, T right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Node<T> left, T right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Node<T> left, T right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Node<T> left, T right)
        {
            return left.CompareTo(right) >= 0;
        }
        public static bool operator <(T left, Node<T> right)
        {
            return right.CompareTo(left) > 0;
        }

        public static bool operator >(T left, Node<T> right)
        {
            return right.CompareTo(left) < 0;
        }

        public static bool operator <=(T left, Node<T> right)
        {
            return right.CompareTo(left) >= 0;
        }

        public static bool operator >=(T left, Node<T> right)
        {
            return right.CompareTo(left) <= 0;
        }
        #endregion
    }
}
