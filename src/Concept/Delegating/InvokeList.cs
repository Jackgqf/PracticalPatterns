using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.Delegating
{
    public class InvokeList
    {
        List<StringAssignmentEventHandler> handlers = new List<StringAssignmentEventHandler>();
        string[] message = new string[3];

        public InvokeList()
        {
            this.handlers.Add(new StringAssignmentEventHandler(AppendHello));
            this.handlers.Add(new StringAssignmentEventHandler(AppendComma));
            this.handlers.Add(new StringAssignmentEventHandler(AppendWorld));
        }

        public void AppendHello(){ this.message[0] = "hello";}

        public void AppendComma() { this.message[1] = ","; }

        public void AppendWorld() { this.message[2] = "world"; }

        public void Invoke()
        {
            this.handlers.ForEach(x => x());
        }

        public string this[int index]
        {
            get
            {
                return message[index];
            }
        }
    }
}
