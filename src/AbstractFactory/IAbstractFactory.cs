using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.AbstractFactory
{
    public interface IAbstractFactory
    {
        IProductA CreateProductA();
        IProductB CreateProductB();
    }
}
