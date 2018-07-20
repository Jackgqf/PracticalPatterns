using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.FactoryMethod
{
    public interface IFactory
    {
        TTarget Create<TTarget>();
        TTarget Create<TTarget>(string name);

        IFactory RegisterType<TTarget, TSource>();
        IFactory RegisterType<TTarget, TSource>(string name);
    }

    public sealed class TypeRegistry
    {
        readonly string DefaultName = Guid.NewGuid().ToString();

        IDictionary<Type, IDictionary<string, Type>> registry =
            new Dictionary<Type, IDictionary<string, Type>>();

        public void RegisterType(Type targetType, Type sourceType)
        {
            RegisterType(targetType, sourceType, DefaultName);
        }

        public void RegisterType(Type targetType, Type sourceType, string name)
        {
            if (targetType == null) throw new ArgumentNullException("targetType");
            if (sourceType == null) throw new ArgumentNullException("sourceType");
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            IDictionary<string, Type> subDictionary;
            if (!registry.TryGetValue(targetType, out subDictionary))
            {
                subDictionary = new Dictionary<string, Type>();
                subDictionary.Add(name, sourceType);
                registry.Add(targetType, subDictionary);
            }
            else
            {
                if (subDictionary.ContainsKey(name))
                    throw new Exception();
                subDictionary.Add(name, sourceType);
            }
        }

        public Type this[Type targetType, string name]
        {
            get
            {
                if (targetType == null) throw new ArgumentNullException("targetType");
                if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
                if (registry.Count() == 0)
                    return null;

                return
                    (registry.Where(x => x.Key == targetType)).FirstOrDefault().Value
                    .Where(x => string.Equals(name, x.Key)).FirstOrDefault().Value;
            }
        }

        public Type this[Type targetType]
        {
            get { return this[targetType, DefaultName]; }
        }

    }

    public class Factory : IFactory
    {
        protected TypeRegistry registry = new TypeRegistry();

        public TTarget Create<TTarget>()
        {
            return (TTarget)Activator.CreateInstance(registry[typeof(TTarget)]);
        }

        public TTarget Create<TTarget>(string name)
        {
            return (TTarget)Activator.CreateInstance(registry[typeof(TTarget), name]);
        }

        public IFactory RegisterType<TTarget, TSource>()
        {
            registry.RegisterType(typeof(TTarget), typeof(TSource));
            return this;
        }

        public IFactory RegisterType<TTarget, TSource>(string name)
        {
            registry.RegisterType(typeof(TTarget), typeof(TSource), name);
            return this;
        }
    }
}
