using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.FactoryMethod.SimpleFactory;

namespace PracticalPatterns.FactoryMethod.Tests.SimpleFactory
{
    [TestClass]
    public class ProductFactoryFixture
    {
        [TestMethod]
        public void TestCreate()
        {
            var product = ProductFactory.Create(Category.A);
            Assert.IsNotNull(product);
            Assert.IsInstanceOfType(product, typeof(ConcreteProductA));
        }
    }
}
