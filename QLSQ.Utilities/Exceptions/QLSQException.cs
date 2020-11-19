using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Utilities.Exceptions
{
    public class QLSQException : Exception
    {
        public QLSQException() { }

        public QLSQException(string message)
            : base(message) { }

        public QLSQException(string message, Exception inner)
            : base(message, inner) { }
    }
}
