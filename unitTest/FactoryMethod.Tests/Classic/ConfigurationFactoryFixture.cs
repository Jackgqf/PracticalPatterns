using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Collections.Specialized;

namespace PracticalPatterns.FactoryMethod.Classic.Tests
{
    [TestClass]
    public class ConfigurationFactoryFixture
    {
        const string SectionName = "factoryMethod.customFactories";
        const string Name = "PracticalPatterns.FactoryMethod.Tests.Classic.IFactory,FactoryMethod.Tests";

        [TestMethod]
        public void Test()
        {
            string typeName = ((NameValueCollection)ConfigurationManager.GetSection(SectionName))[Name];
            Assert.IsTrue(typeof(IFactory).IsAssignableFrom(Type.GetType(typeName)));
        }
    }
}
