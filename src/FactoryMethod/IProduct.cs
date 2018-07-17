using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.FactoryMethod
{
    //abstract product type
    public interface IProduct
    {
        string Name { get; }
    }

    public class ProductA : IProduct
    {
        public string Name { get { return "A"; } }
    }

    public class ProductB : IProduct
    {
        public string Name
        {
            get { return "B"; }
        }
    }
}
