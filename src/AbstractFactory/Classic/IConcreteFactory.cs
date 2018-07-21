using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.AbstractFactory.Classic
{
    public class ConcreteFactory1 : IAbstractFactory
    {
        public virtual IProductA CreateProductA() { return new ProductA1(); }
        public virtual IProductB CreateProductB() { return new ProductB1(); }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public virtual IProductA CreateProductA() { return new ProductA2X(); }
        public virtual IProductB CreateProductB() { return new ProductB2(); }
    }

}
