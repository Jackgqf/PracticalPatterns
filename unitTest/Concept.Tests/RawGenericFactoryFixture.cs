using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Concept.Generics;
using System.Diagnostics;

namespace PracticalPatterns.Concept.Tests
{
    [TestClass]
    public class RawGenericFactoryFixture
    {
        interface IProduct { }
        class ConcreateProduct : IProduct { }

        interface IUser { }
        class ConcreateUserA : IUser { }

        [TestMethod]
        public void Test()
        {
            string typeName = typeof(ConcreateProduct).AssemblyQualifiedName;
            Trace.WriteLine(typeName);
            Trace.WriteLine(typeof(ConcreateProduct));

            var product = new RawGenericFactory<ConcreateProduct>().Create(typeName);
            Assert.IsNotNull(product);
            Assert.IsInstanceOfType(product, typeof(ConcreateProduct));
            Assert.IsTrue(product is IProduct);

            var user = new RawGenericFactory<ConcreateUserA>().Create(typeof(ConcreateUserA).AssemblyQualifiedName);
            Assert.IsNotNull(user);
            Assert.IsInstanceOfType(user, typeof(ConcreateUserA));
            Assert.IsTrue(user is IUser);
        }
    }
}
