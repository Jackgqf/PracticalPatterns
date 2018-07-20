using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.FactoryMethod.SimpleFactory;

namespace PracticalPatterns.FactoryMethod.SimpleFactory.Tests
{
    [TestClass]
    public class FactoryFixture
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsInstanceOfType(new Factory().Create(), typeof(ConcreteProductA));
        }
    }
}
