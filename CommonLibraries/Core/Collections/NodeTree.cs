using System;
using System.Collections.Generic;

namespace TRW.CommonLibraries.Core
{
    public class NodeTree<T> where T : IComparable<T>
    {
        protected Queue<Node<T>> _nodesOrdered;

        public NodeTree()
        {

        }

        public NodeTree(Node<T> root)
            : this()
        {
            Root = root;
        }

        public Node<T> Root { get; set; }

        public Node<T> Current { get; protected set; }

        public TraversalStyles TraversalStyle { get; set; }

        /// <summary>
        /// Go to Root Node and Order Nodes by Traversal Style
        /// </summary>
        /// <returns></returns>
        public bool First()
        {
            if (Root != null)
            {
                _nodesOrdered = new Queue<Node<T>>();
                switch (TraversalStyle)
                {
                    case TraversalStyles.PreOrder:
                        PreOrderTraversal(Root);
                        break;
                    case TraversalStyles.InOrder:
                        InOrderTraversal(Root);
                        break;
                    case TraversalStyles.PostOrder:
                        PostOrderTraversal(Root);
                        break;

                }

                Current = _nodesOrdered.Dequeue();

                return true;
            }
            return false;
        }

        public bool Next()
        {
            if (_nodesOrdered.Count > 0)
            {
                Current = _nodesOrdered.Dequeue();
                return true;
            }

            return false;
        }

        protected void PreOrderTraversal(Node<T> root)
        {
            if (root == null || !root.Visible)
            {
                return;
            }

            _nodesOrdered.Enqueue(root);
            PreOrderTraversal(root.Left);
            PreOrderTraversal(root.Right);
        }

        protected void InOrderTraversal(Node<T> root)
        {
            if (root == null || !root.Visible)
            {
                return;
            }

            InOrderTraversal(root.Left);
            _nodesOrdered.Enqueue(root);
            InOrderTraversal(root.Right);
        }

        protected void PostOrderTraversal(Node<T> root)
        {
            if (root == null || !root.Visible)
            {
                return;
            }

            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
            _nodesOrdered.Enqueue(root);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Root != null)
            {
                return Root.GetEnumerator();
            }
            return null;
        }

        
    }
}
