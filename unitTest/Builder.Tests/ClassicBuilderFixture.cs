using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Builder.Classic;

namespace PracticalPatterns.Builder.Tests
{
    [TestClass]
    public class ClassicBuilderFixture
    {
        [TestMethod]
        public void TestBuilder()
        {
            var maker1 = new VehicleMaker();
            maker1.Builder = new CarBuilder();
            maker1.Construct();
            Assert.AreEqual(4, maker1.Vehicle.Wheels.Count());
            Assert.AreEqual(4, maker1.Vehicle.Lights.Count());

            var maker2 = new VehicleMaker();
            maker2.Builder = new BicycleBuilder();
            maker2.Construct();
            Assert.AreEqual(2, maker2.Vehicle.Wheels.Count());
            Assert.IsNull(maker2.Vehicle.Lights);
        }
    }
}
