using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.DependencyInjection
{
    public class Assembler
    {
        static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            dictionary.Add(typeof(ITimeProvider), typeof(SystemTimeProvider));
        }

        public object Create(Type type)
        {
            if ((type == null) || !dictionary.ContainsKey(type))
            {
                throw new NullReferenceException();
            }
            Type targetType = dictionary[type];
            return Activator.CreateInstance(targetType);
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
    }
}
