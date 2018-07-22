using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.AbstractFactory.Classic;

namespace PracticalPatterns.AbstractFactory.Tests
{
    [TestClass]
    public class AbstractFactoryFixture
    {
        [TestMethod]
        public void Test()
        {
            var factory = new ConcreteFactory1();
            var product1 = factory.CreateProductA();
            var product2 = factory.CreateProductB();
            Assert.IsTrue(product1 is ProductA1);
            Assert.IsTrue(product2 is ProductB1);
        }
    }
}
