using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.FactoryMethod.SimpleFactory
{
    public enum Category
    {
        A,
        B
    }

    public static class ProductFactory
    {
        public static IProduct Create(Category categoty)
        {
            switch (categoty)
            {
                case Category.A:
                    return new ConcreteProductA();
                case Category.B:
                    return new ConcreteProductB();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
