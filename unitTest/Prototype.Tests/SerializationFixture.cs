using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Common;

namespace PracticalPatterns.Prototype.Tests
{
    [TestClass]
    public class SerializationFixture
    {
        [TestMethod]
        public void Test()
        {
            var user = new UserInfo()
            {
                Name = "Joe",
                Age = 10,
                Education = new string[] { "A", "B", "C", "D" }
            };

            var graph = SerializationHelper.SerializeObjectToString(user);
            var clone = SerializationHelper.DeserializeStringToObject<UserInfo>(graph);
            Assert.AreEqual<int>(3, clone.Education.Count());
            Assert.AreNotEqual(user.Age, clone.Age);
            Assert.AreEqual<string>(user.Name, clone.Name);
        }
    }
}
