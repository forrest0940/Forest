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
    public class NodeTests
    {
        [TestMethod()]
        public void SetRightNodeTest()
        {
            Node<double> root = new Node<double>(0);
            root.SetRightNode(1.234);
            Assert.IsTrue(root.GetRightChild().IsRightNode());
            Assert.IsFalse(root.GetRightChild().IsLeftNode());
            //Assert.Fail();
        }
    }
}