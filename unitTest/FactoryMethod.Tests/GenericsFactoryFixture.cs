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

        [TestMethod]
        public void BatchCreateProductByName()
        {
            var batchSize = 5;
            var factory = new BatchFactory();

            //create default product 
            var products = factory.Create(batchSize);
            Assert.AreEqual<int>(batchSize, products.Count());
            Assert.AreEqual<int>(batchSize, products.Count(x => x is ProductA));
            
            //concrete product type by name
            products = factory.Create("a", batchSize);
            Assert.AreEqual<int>(batchSize, products.Count());
            Assert.AreEqual<int>(batchSize, products.Count(x => x is ProductA));

            products = factory.Create("b", batchSize);
            Assert.AreEqual<int>(batchSize, products.Count());
            Assert.AreEqual<int>(batchSize, products.Count(x => x is ProductB));

        }
    }
}
