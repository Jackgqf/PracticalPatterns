using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Singleton.DoubleCheckClassic
{
    public class Singleton
    {
        protected Singleton() { }

        static volatile Singleton instance = null;
        //public static Singleton Instance()
        //{
        //    if (instance == null)
        //    {
        //        lock (typeof(Singleton))
        //        {
        //            if (instance == null)
        //            {
        //                instance = new Singleton();
        //            }
        //        }
        //    }
        //    return instance;
        //}
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (typeof(Singleton))
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
