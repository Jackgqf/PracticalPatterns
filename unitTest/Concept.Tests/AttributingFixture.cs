using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Concept.Attributing;

namespace PracticalPatterns.Concept.Tests
{
    [TestClass]
    public class AttributingFixture
    {
        [Director(3,"BuildPartA")]
        [Director(2,"BuildPartB")]
        [Director(1,"BuildPartC")]
        class AttributedBuilder : IAttributeBuilder
        {
            IList<string> log = new List<string>();
            public IList<string> Log { get { return log; } }

            public void BuildPartA() { log.Add("a"); }
            public void BuildPartB() { log.Add("b"); }
            public void BuildPartC() { log.Add("c"); }
        }

        [TestMethod]
        public void BuildAccordingToAttribute()
        {
            IAttributeBuilder builder = new AttributedBuilder();
            new Director().BuildUp(builder);

            Assert.AreEqual<string>("a", builder.Log[0]);
            Assert.AreEqual<string>("b", builder.Log[1]);
            Assert.AreEqual<string>("c", builder.Log[2]);
        }
    }
}
