using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.Generics
{
    public class RawGenericFactory<T>
    {
        public T Create(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new ArgumentNullException("typeName");
            }
            return (T)Activator.CreateInstance(Type.GetType(typeName));
        }
    }
}
