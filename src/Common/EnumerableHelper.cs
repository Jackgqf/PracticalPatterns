using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Common
{
    public class EnumerableHelper
    {
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null)
            {
                throw new ArgumentException("sequence");
            }
            if (action == null)
            {
                throw new ArgumentException("action");
            }
            foreach (var item in sequence)
            {
                action(item);
            }
        }
    }
}
