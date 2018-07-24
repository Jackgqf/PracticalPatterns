using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Prototype.Classic
{
    public class Indicator { }

    public interface IPrototype
    {
        IPrototype Clone();
        string Name { get; set; }
        Indicator Signal { get; }
    }
}
