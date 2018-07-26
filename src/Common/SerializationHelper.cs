using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace PracticalPatterns.Common
{
    public enum FormatterType
    {
        Soap,
        Binary
    }

    public static class SerializationHelper
    {
        const FormatterType DefaultFormatterType = FormatterType.Binary;

        static IRemotingFormatter GetFormatter(FormatterType formatterType)
        {
            switch (formatterType)
            {
                case FormatterType.Soap:
                    return new SoapFormatter();
                case FormatterType.Binary:
                    return new BinaryFormatter();
            }
            throw new NotSupportedException();
        }

        public static string SerializeObjectToString(object graph, FormatterType formatterType = DefaultFormatterType)
        {
            using (var memoryStream = new MemoryStream())
            {
                var formatter = GetFormatter(formatterType);
                formatter.Serialize(memoryStream, graph);
                var arrGraph = memoryStream.ToArray();
                return Convert.ToBase64String(arrGraph);
            }
        }

        public static T DeserializeStringToObject<T>(string graph, FormatterType formatterType = DefaultFormatterType)
        {
            var arrGraph = Convert.FromBase64String(graph);
            using (var memoryStream = new MemoryStream(arrGraph))
            {
                var formatter = GetFormatter(formatterType);
                return (T)formatter.Deserialize(memoryStream);
            }
        }
    }
}
