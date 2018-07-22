using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.AbstractFactory.Async
{
    public interface IAbstractFactory
    {
        IProduct Create();
    }
    public interface IAbstractFactoryWithNotifier : IAbstractFactory
    {
        void Create(Action<IProduct> callback);
    }
}
