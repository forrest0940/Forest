using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        [TestMethod()]
        public void SwapNodeTest()
        {
            Node<int> node = new Node<int>(10);
            TraversalBinaryTree<int> traversalBinaryTree = new TraversalBinaryTree<int>(node);
            Node<int> nodeA = new Node<int>(11);
            Node<int> nodeB = new Node<int>(9);
            Console.WriteLine("Swap start");
            traversalBinaryTree.InsertAfter(node , nodeA);
            traversalBinaryTree.InsertBefore(node , nodeB);
            int nBefore = node.GetValue();
            int aBefore = nodeA.GetValue();
            traversalBinaryTree.Iterate(traversalBinaryTree.GetRoot());
            Console.WriteLine("Swap");
            traversalBinaryTree.SwapNode( node , nodeA);
            traversalBinaryTree.Iterate(traversalBinaryTree.GetRoot());
            int nAfter = node.GetValue();
            int aAfter = nodeA.GetValue();
            Assert.AreEqual(nBefore, aAfter);
            Assert.AreEqual(nAfter, aBefore);
        }
    }
}