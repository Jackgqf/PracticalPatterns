using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;

namespace PracticalPatterns.FactoryMethod.Generics
{
    public interface IFactory
    {
        IProduct Create();
        IProduct Create(string name);
    }

    public class ProductRegistry
    {
        const string SectionName = "concreteProducts";
        static NameValueCollection collection =
            (NameValueCollection)ConfigurationManager.GetSection(SectionName);

        public Type this[string name]
        {
            get { return Type.GetType(collection[name]); }
        }
    }

    public class Factory : IFactory
    {
        public const string DefaultName = "DEFAULT";
        public readonly ProductRegistry productRegistry = new ProductRegistry();

        public IProduct Create()
        {
            return (IProduct)Activator.CreateInstance(productRegistry[DefaultName]);
        }
        public IProduct Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException("name");
            }
            return (IProduct)Activator.CreateInstance(productRegistry[name]);
            
        }
    }
}
