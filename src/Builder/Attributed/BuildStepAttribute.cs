using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Builder.Attributed
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple=false)]
    public sealed class BuildStepAttribute:Attribute
    {
        private int _sequence;
        private int _times;
        public int Sequence { get { return this._sequence; } }
        public int Times { get { return this._times; } }

        public BuildStepAttribute(int sequence, int times)
        {
            if ((sequence <= 0) || (times <= 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            this._sequence = sequence;
            this._times = times;
        }

        public BuildStepAttribute(int sequence) : this(sequence, 1) { }
    }
}
