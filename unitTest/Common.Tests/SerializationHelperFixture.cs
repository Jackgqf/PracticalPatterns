using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;

namespace PracticalPatterns.Common.Tests
{
    [TestClass]
    public class SerializationHelperFixture
    {
        [Serializable]
        class UserInfo
        {
            public string Name;
            public readonly IList<string> Education = new List<string>();

            public UserInfo GetShallowCopy() { return (UserInfo)this.MemberwiseClone(); }
            public UserInfo GetDeepCopy()
            {
                return SerializationHelper.DeserializeStringToObject<UserInfo>(SerializationHelper.SerializeObjectToString(this));
            }
        }

        [TestMethod]
        public void ShallowCopyTest()
        {
            var user1 = new UserInfo();
            user1.Name = "joe";
            user1.Education.Add("A");
            var user2 = user1.GetShallowCopy();

            Assert.AreEqual<string>(user1.Name, user2.Name);
            Assert.AreEqual<string>(user1.Education[0], user2.Education[0]);
            user2.Name = "Nancy";
            user2.Education[0] = "B";
            Assert.AreNotEqual<string>(user1.Name, user2.Name);
            Assert.AreEqual<string>(user1.Education[0], user2.Education[1]);
        }

        [TestMethod]
        public void DeepCopyTest()
        {
            var user1 = new UserInfo();
            user1.Name = "Joe";
            user1.Education.Add("A");
            var user2 = user1.GetDeepCopy();

            Assert.AreEqual<string>(user1.Name, user2.Name);
            Assert.AreEqual<string>(user1.Education[0], user2.Education[0]);

            user2.Name = "Nancy";
            user2.Education[0] = "B";
            Assert.AreNotEqual<string>(user1.Name, user2.Name);
            Assert.AreNotEqual<string>(user1.Education[0], user2.Education[0]);
        }

        class Inner { }
        class Middle { Inner sub = new Inner();}
        class Outer { Middle sub = new Middle();}

        [Serializable]
        class Client
        {
            Outer outer = new Outer();
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void CannotSerialization()
        {
            //run error
            var graph = SerializationHelper.SerializeObjectToString(new Client());
        }

        [Serializable]
        class Parent { }

        [Serializable]
        class Teacher { }

        [Serializable]
        class Child
        {
            [NonSerialized]
            public Parent[] Parents;

            public Teacher Teacher { get; set; }
        }

        [TestMethod]
        public void Test()
        {
            var child = new Child();
            child.Teacher = new Teacher();
            child.Parents = new Parent[2];
            Assert.IsNotNull(child.Parents);
            Assert.IsNotNull(child.Teacher);

            var clone = SerializationHelper.DeserializeStringToObject<Child>(SerializationHelper.SerializeObjectToString(child));
            Assert.IsNull(clone.Parents);
            Assert.IsNotNull(clone.Teacher);
        }
    }
}
