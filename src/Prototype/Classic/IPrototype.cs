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
        string Name { get; set; }// value clone
        Indicator Signal { get; }// ref clone
    }

    public class ConcretePrototype : IPrototype
    {
        private string name = string.Empty;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private Indicator _signal = new Indicator();
        public Indicator Signal { get { return this._signal; } }

        public IPrototype Clone() { return (IPrototype)this.MemberwiseClone(); }
    }
}
