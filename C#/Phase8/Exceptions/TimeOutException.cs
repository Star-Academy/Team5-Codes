using System;

namespace Phase8.Exceptions
{
    class TimeOutException : Exception
    {
        public TimeOutException(string message) : base(message)
        {
        }
    }
}
