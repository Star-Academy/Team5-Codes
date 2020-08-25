using System;
using System.Collections.Generic;
using System.Text;

namespace Phase8.Exceptions
{
    class TimeOutException : Exception
    {
        public TimeOutException(string message) : base(message)
        {
        }
    }
}
