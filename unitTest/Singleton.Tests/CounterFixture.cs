using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Singleton.SimplestCounter;
using PracticalPatterns.Common;
using System.Threading;

namespace PracticalPatterns.Singleton.Tests
{
    [TestClass]
    public class CounterFixture
    {
        const int TestTimes = 10;

        [TestMethod]
        public void SequentialExecuteCounter()
        {
            var c1 = Counter.Instance;
            var c2 = Counter.Instance;

            Assert.IsTrue(c1 == c2);
            Assert.AreEqual<int>(c1.GetHashCode(), c2.GetHashCode());

            var counter = Counter.Instance;
            for (int i = 0; i < TestTimes; i++)
            {
                Assert.AreEqual(i + 1, counter.Next);
            }
            counter.Reset();
            for (int i = 0; i < TestTimes; i++)
            {
                Assert.AreEqual(i + 1, counter.Next);
            }
        }

        static IList<Counter> counters;

        [TestMethod]
        public void ParallelExecuteCounter()
        {
            counters = new List<Counter>();
            TestHarness.Parallel(
                ThreadBody,                                                                                                                                                                                                              
                ThreadBody,
                ThreadBody);

            Assert.AreEqual<int>(1, counters.Distinct().Count());
            Assert.AreEqual<int>(1, Counter.Instance.Next);
        }

        void ThreadBody()
        {
            for (int i = 0; i < TestTimes; i++)
            {
                Thread.Sleep(new Random().Next() % 53);
                counters.Add(Counter.Instance);
            }
        }
    }
}
