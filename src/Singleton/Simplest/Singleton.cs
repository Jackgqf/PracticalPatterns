using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Singleton.Simplest
{
    public class Singleton
    {
        Singleton() { }
        public static readonly Singleton Instance = new Singleton();
    }
}
