using System;

namespace Forest
{
    public class BinaryTree<T>
    {
        private Node<T> root;

        public BinaryTree(Node<T> rootNode)
        {
            root = rootNode;
        }

        public void SwapNode(Node<T> nodeA, Node<T> nodeB)
        { 
            T tempBValue = nodeB.GetValue();

            nodeB.SetValue(nodeA.GetValue());
            nodeA.SetValue(tempBValue);

            if(nodeA.Equals(root))
            {
                root = nodeB;
            }
            else if(nodeB.Equals(root))
            {
                root = nodeA;
            }
        }

        public Node<T> GetRoot()
        {
            return root;
        }
    }


    /// <summary>
    /// Binary tree that it's nodes are in traversal order 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TraversalBinaryTree<T> : BinaryTree<T>
    {
        public TraversalBinaryTree(Node<T> rootNode) : base(rootNode)
        {

        }
        /// <summary>
        /// Get the order of the tree in traversal order
        /// Rewirte Console.WriteLine() for real iterate purpose
        /// </summary>
        /// <param name="n"></param>
        public virtual void Iterate(Node<T> n)
        {
            if (n == null)
                return;
            Iterate(n.GetLeftChild());
            Console.WriteLine(n.GetValue().ToString());
            Iterate(n.GetRightChild());
        }

        public Node<T> SubtreeFirst(Node<T> n)
        {
            Node<T> node = new Node<T>(n);
            Node<T> left;
            bool leftLeast = false;
            while(!leftLeast)
            {
                left = node.GetLeftChild();
                if(left == null)
                {
                    leftLeast = true;
                }
                else
                {
                    node = left;
                }
            }
            return node;
        }

        public Node<T> SubtreeLast(Node<T> n)
        {
            Node<T> node = new Node<T>(n);
            Node<T> right;
            bool rightLeast = false;
            while(!rightLeast)
            {
                right = node.GetRightChild();
                if(right == null)
                {
                    rightLeast = true;
                }
                else
                {
                    node = right;
                }
            }
            return node;
        }

        /// <summary>
        /// Next after node in tree's traversal order
        /// </summary>
        public Node<T> Successor(Node<T> node)
        {
            if(node.GetRightChild() != null)
            {
                return SubtreeFirst(node.GetRightChild());
            }
            else
            {
                Node<T> n = new Node<T>(node).GetParent();
                while(n.IsLeftNode())
                {
                    n = n.GetParent();
                }
                return n;
            }
        }

        public Node<T> PreSuccessor(Node<T> node)
        {
            if(node.GetLeftChild() != null)
            {
                return SubtreeLast(node.GetLeftChild());
            }
            return null;
        }

        public  void InsertBefore(Node<T> node , Node<T> newNode)
        {
            if(node.GetLeftChild() == null)
            {
                node.SetLeftNode(newNode);
            }
            else
            {
                SubtreeLast(node.GetLeftChild()).SetRightNode(newNode);
            }
        }

        public void InsertAfter(Node<T> node , Node<T> newNode)
        {
            if(node.GetRightChild() == null)
            {
                node.SetRightNode(newNode);
            }
            else
            {
                SubtreeFirst(node.GetRightChild()).SetLeftNode(newNode);
            }
        }


        public void RemoveNode(Node<T> node)
        {
            if (node.IsLeaf())
            {
                if (node.IsLeftNode())
                {
                    node.GetParent().SetLeftNode(null);
                }
                else
                {
                    node.GetParent().SetRightNode(null);
                }
                node = null;
            }
            else
            {
                Node<T> preNode = PreSuccessor(node);
                SwapNode( node,  preNode);
                RemoveNode(node);
            }
        }

        public void AddNode(Node<T> node)
        {

        }

    }
    
}
