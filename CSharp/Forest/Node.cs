using System;
using System.Collections.Generic;
using System.Text;

namespace Forest
{
    public class Node<T>
    {
        private Node<T> parent;
        private Node<T> leftChild;
        private Node<T> rightChild;
        private T value;
        public int Size { get; }

        public Node(T Value, Node<T> Parent = null, Node<T> LeftChile = null, Node<T> RightChile = null)
        {
            value = Value;
            parent = Parent;
            leftChild = LeftChile;
            rightChild = RightChile;
            Size = 1;
            if(LeftChile != null)
            {
                Size += LeftChile.Size;
            }
            if(RightChile != null)
            {
                Size += RightChile.Size;
            }
        }

        public Node(Node<T> node)
        {
            value = node.GetValue();
            parent = node.GetParent();
            leftChild = node.GetLeftChild();
            rightChild = node.GetRightChild();
        }

        public void SetValue(T Value)
        {
            value = Value;
        }

        public void SetParent(Node<T> node)
        {
            parent = node;
        }

        public void SetLeftNode(T Value)
        {
            leftChild = new Node<T>(Value, this);
        }

        public void SetLeftNode(Node<T> Node)
        {
            leftChild = Node;
            Node.SetParent(this);
        }

        public void SetRightNode(T Value)
        {
            rightChild = new Node<T>(Value, this);
        }

        public void SetRightNode(Node<T> Node)
        {
            rightChild = Node;
            Node.SetParent(this);
        }

        public Node<T> GetParent()
        {
            return parent;
        }

        public Node<T> GetLeftChild()
        {
            return leftChild;
        }

        public Node<T> GetRightChild()
        {
            return rightChild;
        }

        public T GetValue()
        {
            return value;
        }

        public bool IsRightNode()
        {
            if (GetParent() == null)
            {
                return false;
            }
            return this.Equals(GetParent().GetRightChild());
        }

        public bool IsLeftNode()
        {
            if (GetParent() == null)
            {
                return false;
            }
            return this.Equals(GetParent().GetLeftChild());
        }

        public bool IsLeaf()
        {
            if (leftChild == null && rightChild == null)
                return true;

            return false;
        }
    }
}
