using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using PracticalPatterns.Builder.Attributed;
using System.Reflection;

namespace PracticalPatterns.Builder.Tests
{
    [TestClass]
    public class AttributedBuilderFixture
    {
        #region test initialize
        static Action<string, Action<string>> buildPartHandler = (x, y) =>
            {
                Trace.WriteLine("add" + x);
                y(x);
            };

        class Car
        {
            public IList<string> Parts { get; private set; }
            public Car() { Parts = new List<string>(); }

            [BuildStep(2,4)]
            public void AddWheel() { buildPartHandler("wheel", Parts.Add); }

            public void AddEngine() { buildPartHandler("engine", Parts.Add); }

            [BuildStep(1)]
            public void AddBody() { buildPartHandler("body", Parts.Add); }
        }

        class Computer
        {
            public string Bus { get; private set; }
            public string Monitor { get; private set; }
            public string Disk { get; private set; }
            public string Memory { get; private set; }
            public string Keyboard { get; private set; }
            public string Mouse { get; private set; }

            static PropertyInfo[] properties = typeof(Computer).GetProperties();

            static Action<string> GetSetter(Computer target, string name)
            {
                var property = properties.Where(x => string.Equals(x.Name, name)).FirstOrDefault();
                return x => property.SetValue(target, x, null);
            }

            [BuildStep(1)]
            public void LayoutBus()
            {
                buildPartHandler("bus", GetSetter(this, "Bus"));
            }

            [BuildStep(2)]
            public void AddDiskAndMemory()
            {
                buildPartHandler("disk", GetSetter(this, "Disk"));
                buildPartHandler("16G memory", GetSetter(this, "Memory"));
            }

            [BuildStep(3)]
            public void AddUserInputDevice()
            {
                buildPartHandler("USB mouse", GetSetter(this, "Mouse"));
                buildPartHandler("keyboard", GetSetter(this, "Keyboard"));
            }

            [BuildStep(4)]
            public void ConnectMonitor()
            {
                buildPartHandler("monitor", GetSetter(this, "Monitor"));
            }
        }
        #endregion

        [TestMethod]
        public void BuildComputerByAttributeDirection()
        {
            Trace.WriteLine("\nassembly computer");
            var computer = new Computer();
            Assert.IsNull(computer.Keyboard);
            Assert.IsNull(computer.Memory);
            computer = new Builder<Computer>().BuildUp();
            Assert.IsNotNull(computer.Bus);
            Assert.IsNotNull(computer.Monitor);
            Assert.IsNotNull(computer.Disk);
            Assert.IsNotNull(computer.Memory);
            Assert.IsNotNull(computer.Keyboard);
            Assert.IsNotNull(computer.Mouse);
        }

        [TestMethod]
        public void BuildCarByAttributeDirection()
        {
            Trace.WriteLine("build car");
            var car = new Builder<Car>().BuildUp();
            Assert.IsNotNull(car);
            Assert.IsFalse(car.Parts.Contains("engine")); // can not run
            Assert.AreEqual<string>("body", car.Parts.ElementAt(0));
            for (var i = 1; i <= 4; i++)
                Assert.AreEqual<string>("wheel", car.Parts.ElementAt(i));
        }
    }
}
