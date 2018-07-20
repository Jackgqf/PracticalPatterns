using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.FactoryMethod;

namespace PracticalPatterns.FactoryMethod.Classic.Tests
{
    public class Assembler
    {
        static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            dictionary.Add(typeof(IFactory), typeof(FactoryA));
        }

        public object Create(Type type)
        {
            if ((type == null) || !dictionary.ContainsKey(type))
            {
                throw new NullReferenceException();
            }
            return Activator.CreateInstance(dictionary[type]);
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public void Assembly(Client client)
        {
            client.Factory = Create<IFactory>();
        }
    }

    public interface IFactory
    {
        IProduct Create();
    }

    public class FactoryA : IFactory
    {
        public IProduct Create()
        {
            return new ProductA();
        }
    }

    public class FactoryB : IFactory
    {
        public IProduct Create()
        {
            return new ProductB();
        }
    }

    [TestClass]
    public class Client
    {
        public IFactory Factory { get; set; }
        public IProduct Product { get { return Factory.Create(); } }

        [TestMethod]
        public void FactoryWithAssembler()
        {
            var client = new Client();
            new Assembler().Assembly(client);

            Assert.IsInstanceOfType(client.Factory, typeof(FactoryA));
            Assert.IsInstanceOfType(client.Product, typeof(ProductA));
        }
    }
}
