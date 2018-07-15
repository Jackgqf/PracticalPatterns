using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Concept.DependencyInjection;

namespace PracticalPatterns.Concept.Tests.DependencyInjection.Setter
{
    [TestClass]
    public class SetterInjectionFixture
    {
        [TestMethod]
        public void Test()
        {
            var client = new Client() { TimeProvider = (new Assembler()).Create<ITimeProvider>() };
        }
    }

}
