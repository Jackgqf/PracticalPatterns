using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.DependencyInjection.Example1
{
    class TimeProvider
    {
        public DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
        }
    }

    public class Client
    {
        public int GetYear()
        {
            TimeProvider timeProvider = new TimeProvider();
            return timeProvider.CurrentDate.Year;
        }
    }
}
