using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Concept.Delegating;

namespace PracticalPatterns.Concept.Tests
{
    [TestClass]
    public class DelegatingFixture
    {
        [TestMethod]
        public void SimpleAysncInvoker()
        {
            new AsyncInvoker();
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void AysncInvokeList()
        {
            var list = new InvokeList();
            list.Invoke();
            Assert.AreEqual<string>("hello,world", list[0] + list[1] + list[2]);
        }

        [TestMethod]
        public void MulticastDelegateInvoke()
        {
            var invoker = new MulticastDelegateInvoker();
            Assert.AreEqual<string>("hello,world", invoker[0] + invoker[1] + invoker[2]);
        }
    }
}
