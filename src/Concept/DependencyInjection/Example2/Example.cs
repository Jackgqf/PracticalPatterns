using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.DependencyInjection.Example2
{
    interface ITimeProvider
    {
        DateTime CurrentDate { get; }
    }

    class TimeProvider : ITimeProvider
    {
        public DateTime CurrentDate { get { return DateTime.Now; } }
    }

    public class Client
    {
        public int GetYear()
        {
            ITimeProvider timeProvider = new TimeProvider();
            return timeProvider.CurrentDate.Year;
        }

    }
}
