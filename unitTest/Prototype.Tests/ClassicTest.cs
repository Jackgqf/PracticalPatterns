using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Prototype.Classic;

namespace PracticalPatterns.Prototype.Tests
{
    [TestClass]
    public class ClassicTest
    {
        IPrototype sample;

        [TestInitialize]
        public void Initialize()
        {
            sample = new ConcretePrototype();
        }

        [TestMethod]
        public void Test()
        {
            var mirrorImage = sample.Clone();
            Assert.AreEqual<int>(sample.Signal.GetHashCode(), mirrorImage.Signal.GetHashCode());
            Assert.AreEqual<string>(mirrorImage.Name, sample.Name);

            sample.Name = "A";
            Assert.AreNotEqual<string>("A", mirrorImage.Name);
            mirrorImage = sample.Clone();
            Assert.AreEqual<string>("A",mirrorImage.Name);
            Assert.IsInstanceOfType(mirrorImage,typeof(ConcretePrototype));   
        }
    }
}
