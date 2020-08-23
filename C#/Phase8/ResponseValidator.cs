using Nest;
using System;

namespace Phase8
{
    class ResponseValidator
    {
        public static void Validate(ISearchResponse<Person> response)
        {

            if (response.ApiCall.Success && response.IsValid)
            {
                Console.WriteLine("request took " + response.Took + "ms and it has " + response.Total + " results.");
                Program.ShowResult(response.Documents);
                return;
            }

            if (response.OriginalException != null)
                throw new Exception("Exception occurred while processing the request.");

            if (response.ServerError != null)
                throw new Exception("error occurred in the server side of the process.");

            if (response.TerminatedEarly)
                throw new Exception("request terminated earlier than it was supposed to.");

            if (response.TimedOut)
                throw new Exception("request timed out!");
        }
    }
}
