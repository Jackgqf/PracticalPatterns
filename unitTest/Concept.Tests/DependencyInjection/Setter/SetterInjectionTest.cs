using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Concept.DependencyInjection;

namespace PracticalPatterns.Concept.Tests.DependencyInjection.Setter
{
    class Client
    {
        public ITimeProvider TimeProvider { get; set; }
    }

    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public void Test()
        {
            ITimeProvider timeProvider = new Assembler().Create<ITimeProvider>();
            Assert.IsNotNull(timeProvider);
            Client client = new Client();
            client.TimeProvider = timeProvider;
        }
    }
}
