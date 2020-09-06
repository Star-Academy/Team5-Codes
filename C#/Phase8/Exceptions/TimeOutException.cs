using System;

namespace Phase8.Exceptions
{
    public class TimeOutException : Exception
    {
        public TimeOutException(string message) : base(message)
        {
        }
    }
}
