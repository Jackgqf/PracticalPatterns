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

    public interface IBatchFactory : IFactory
    {
        IEnumerable<IProduct> Create(string name, int quantity);
        IEnumerable<IProduct> Create(int quantity);
    }

    public class BatchFactory : Factory, IBatchFactory
    {
        IEnumerable<T> InternalCreate<T>(Type type, int quantity)
        {
            if (quantity <= 0) throw new IndexOutOfRangeException("quantity");
            if (type == null) throw new ArgumentNullException("type");
            IList<T> result = new List<T>();
            for (int i = 0; i < quantity; i++)
            {
                result.Add((T)Activator.CreateInstance(type));
            }
            return result;
        }
       
        public IEnumerable<IProduct> Create(int quantity)
        {
            if (quantity <= 0)
            {
                throw new IndexOutOfRangeException("quantity");
            }
            return InternalCreate<IProduct>(productRegistry[DefaultName], quantity);
        }

        public IEnumerable<IProduct> Create(string name, int quantity)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (quantity <= 0) throw new IndexOutOfRangeException("quantity");
            return InternalCreate<IProduct>(productRegistry[name], quantity);
        }
    }
}
