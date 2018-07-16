using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Concept.DependencyInjection;

namespace PracticalPatterns.Concept.Tests.DependencyInjection.Interfacer
{
    [TestClass]
    public class InterfaceInjectionFixture
    {
        class Client<T> : ITimeProvider
            where T : ITimeProvider
        {
            public T Provider { get; set; }

            public DateTime CurrentDate
            {
                get { return Provider.CurrentDate; }
            }
        }

        [TestMethod]
        public void Test()
        {
            var client = new Client<ITimeProvider>(){Provider = new Assembler().Create<ITimeProvider>()};

            Assert.IsNotNull(client);
            Assert.IsInstanceOfType(client.Provider, typeof(SystemTimeProvider));

            Assert.IsInstanceOfType(client.Provider.CurrentDate, typeof(DateTime));
            Assert.IsTrue(typeof(ITimeProvider).IsAssignableFrom(client.GetType()));
        }
    }
}
