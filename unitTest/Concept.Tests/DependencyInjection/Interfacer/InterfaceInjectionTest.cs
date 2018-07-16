using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Concept.DependencyInjection;

namespace PracticalPatterns.Concept.Tests.DependencyInjection.Interfacer
{
    interface IobjectWithTimeProvider
    {
        ITimeProvider TimeProvider { get; set; }
    }

    class Client : IobjectWithTimeProvider
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
            IobjectWithTimeProvider objectWithProvider = new Client();
            objectWithProvider.TimeProvider = timeProvider;
        }
    }
    
}
