using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.AbstractFactory.Async;

namespace PracticalPatterns.AbstractFactory.Tests.Async
{
    [TestClass]
    public class FactoryFixture
    {
        class ConcreteProduct : IProduct { }
        class ConcreteFactory : IAbstractFactoryWithNotifier
        {
            public IProduct Create()
            {
                return new ConcreteProduct();
            }
            public void Create(Action<IProduct> callback)
            {
                callback(Create());
            }
        }

        class Subscribe
        {
            public IProduct Product { get; set; }
        }

        [TestMethod]
        public void Test()
        {
            IAbstractFactoryWithNotifier factory = new ConcreteFactory();
            Subscribe subscriber = new Subscribe();
            Assert.IsNull(subscriber.Product);
            //subscriber.Product = factory.Create()
            factory.Create((x) => { subscriber.Product = x; });
            Assert.IsNotNull(subscriber.Product);
            Assert.IsTrue(subscriber.Product is ConcreteProduct);

        }
    }
}
