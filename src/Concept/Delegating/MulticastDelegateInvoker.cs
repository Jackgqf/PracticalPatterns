using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.Delegating
{
    public class MulticastDelegateInvoker
    {
        string[] message = new string[3];

        public string this[int index] { get { return message[index]; } }

        //public MulticastDelegateInvoker()
        //{
        //    StringAssignmentEventHandler handlers = null;
        //    handlers += new StringAssignmentEventHandler(AppendHello);
        //    handlers += new StringAssignmentEventHandler(AppendComma);
        //    handlers += new StringAssignmentEventHandler(AppendWorld);
        //    handlers();
        //}

        #region Lambda
        public MulticastDelegateInvoker()
        {
            StringAssignmentEventHandler handlers = null;
            handlers += () => message[0] = "hello";
            handlers += () => message[1] = ",";

        }
        #endregion

        public void AppendHello() { message[0] = "hello"; }
        public void AppendComma() { message[1] = ","; }
        public void AppendWorld() { message[2] = "world"; }
    }
}
