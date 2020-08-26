using System;
using System.Collections.Generic;
using System.Text;

namespace Phase8.Exceptions
{
    class ServerException : Exception
    {
        public ServerException(string message) : base(message)
        {

        }
    }
}
