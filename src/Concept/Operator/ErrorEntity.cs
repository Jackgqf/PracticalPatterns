using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.Operator
{
    public class ErrorEntity
    {
        private IList<string> messages = new List<string>();
        private IList<int> codes = new List<int>();

        public IList<string> Messages { get { return messages; } }
        public IList<int> Codes { get { return codes; } }

        public static ErrorEntity operator +(ErrorEntity errorEntity, string message)
        {
            errorEntity.messages.Add(message);
            return errorEntity;
        }

        public static ErrorEntity operator +(ErrorEntity errorEntity, int code)
        {
            errorEntity.Codes.Add(code);
            return errorEntity;
        }
    }
}
