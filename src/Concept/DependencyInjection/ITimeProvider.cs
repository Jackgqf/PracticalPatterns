using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.DependencyInjection
{
    public interface ITimeProvider
    {
        DateTime CurrentDate { get; }
    }
}
