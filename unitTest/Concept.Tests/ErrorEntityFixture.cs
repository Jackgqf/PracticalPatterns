using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Concept.Operator;
using System.Diagnostics;

namespace PracticalPatterns.Concept.Tests
{
    [TestClass]
    public class ErrorEntityFixture
    {
        [TestMethod]
        public void Test()
        {
            var entity = new ErrorEntity();
            entity += "user name cannot be null";
            entity += "password cannot be null";
            entity += "error\n";
            entity += 1;
            entity += 2;
            Assert.AreEqual(3, entity.Messages.Count);
            Assert.AreEqual(2, entity.Codes.Count);
            Trace.WriteLine(String.Join("\n", entity.Messages));
        }
    }
}
