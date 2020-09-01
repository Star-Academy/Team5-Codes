using System;

namespace Phase8.Exceptions
{
    public class RequestTermination : Exception
    {
        public override string Message { get; }

        public RequestTermination(string message) : base(message)
        {
            Message = message;
        }
    }
}
