using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.AbstractFactory
{
    public interface IProductA { }
    public interface IProductB { }

    public class ProductA1 : IProductA { }
    public class ProductA2X : IProductA { }
    public class ProductA2Y : IProductA { }

    public class ProductB1 : IProductB { }
    public class ProductB2 : IProductB { }
}
