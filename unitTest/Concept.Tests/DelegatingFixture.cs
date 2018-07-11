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

        [TestMethod]
        public void EventMonitorSimulate()
        {
            Order order1 = new Order();
            order1.Create();    //AddedTimes = 1;
            order1.ChangeDate();//ModifiedTimes = 1;
            order1.ChangeDate();//ModifiedTimes = 2;
            order1.ChangeOwner();//ModifiedTimes = 3;

            Order order2 = new Order();
            order2.Create();        //AddedTimes = 2;
            order2.ChangeID();      //ModifiedTimes = 4;
            order2.ChangeOwner();   //ModifiedTimes = 5;

            Assert.AreEqual<int>(2, EventMonitor.AddedTimes);
            Assert.AreEqual<int>(5, EventMonitor.ModifiedTmes);
        }
    }
}
