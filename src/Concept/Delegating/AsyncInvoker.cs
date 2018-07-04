using System;
using System.Diagnostics;
using System.Threading;

namespace PracticalPatterns.Concept.Delegating
{
    public class AsyncInvoker
    {
        static void OnTimerInterval(object state)
        {
            Trace.WriteLine(state as string);
        }

        public AsyncInvoker()
        {
            new Timer(new TimerCallback(OnTimerInterval), "slow", 2500, 2500);
            new Timer(new TimerCallback(OnTimerInterval), "fast", 2000, 2000);
            Trace.WriteLine("method");
        }
    }
}
