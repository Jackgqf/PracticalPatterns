using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PracticalPatterns.Prototype
{
    [Serializable]
    public class UserInfo : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Education { get; set; }

        public UserInfo() { }

        protected UserInfo(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Education = (string[])info.GetValue("Education", typeof(string[]));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Education", Education.Take(3).ToArray());
        }
    }
}
