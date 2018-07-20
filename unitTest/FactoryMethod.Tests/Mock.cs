using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.FactoryMethod.Tests
{
    public interface IFruit { }
    public class Apple : IFruit { }
    public class Orange : IFruit { }

    public interface IVehicle { }
    public class Bicycle : IVehicle { }
    public class Train : IVehicle { }
    public class Car : IVehicle { }
}
