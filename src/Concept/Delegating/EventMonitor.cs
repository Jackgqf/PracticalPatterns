using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.Delegating
{
    public class Order
    {
        public void Create()
        {
            EventMonitor.Added(this, null);
        }

        public void ChangeOwner()
        {
            EventMonitor.Modified(this, null);
        }

        public void ChangeID()
        {
            EventMonitor.Modified(this, null);
        }

        public void ChangeDate()
        {
            EventMonitor.Modified(this, null);
        }
    }

    public static class EventMonitor
    {
        public static EventHandler<EventArgs> Added;
        public static EventHandler<EventArgs> Modified;

        static EventMonitor()
        {
            Added = OnAdded;
            Modified = OnModified;
        }

        public static int AddedTimes { get; private set; }
        public static int ModifiedTmes { get; private set; }

        static void OnAdded(object sender, EventArgs args)
        {
            AddedTimes++;
        }
        static void OnModified(object sender, EventArgs args)
        {
            ModifiedTmes++;
        }
    }
}
