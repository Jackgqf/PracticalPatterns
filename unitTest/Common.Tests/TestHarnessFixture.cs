using System;
using System.Collections.Generic;
using System.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticalPatterns.Common.Tests
{
    [TestClass]
    public class TestHarnessFixture
    {
        IList<string> recoder = new List<string>();

        [TestMethod]
        public void TestParallelExecution()
        {
            var start = DateTime.Now;
            TestHarness.Parallel
                (
                    () => { Thread.Sleep(2000); recoder.Add("A"); },
                    () => { Thread.Sleep(3000); recoder.Add("B"); },
                    () => { Thread.Sleep(1500); recoder.Add("C"); }
                );
            var end = DateTime.Now;

            //max execution time span
            Assert.AreEqual<int>(3, (end - start).Seconds);

            //execution sequence
            Assert.AreEqual<string>("C", recoder[0]);
            Assert.AreEqual<string>("A", recoder[1]);
            Assert.AreEqual<string>("B", recoder[2]);
        }
    }
}
