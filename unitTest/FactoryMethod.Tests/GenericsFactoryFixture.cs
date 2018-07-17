using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.FactoryMethod.Generics;

namespace PracticalPatterns.FactoryMethod.Tests
{
    [TestClass]
    public class GenericsFactoryFixture
    {
        [TestMethod]
        public void CreateProductByName()
        {
            var factory = new Factory();

            Assert.IsInstanceOfType(factory.Create(), typeof(ProductA));
            Assert.IsInstanceOfType(factory.Create("a"), typeof(ProductA));
            Assert.IsInstanceOfType(factory.Create("b"), typeof(ProductB));
        }
    }
}
