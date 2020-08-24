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
                Output.Write("request took " + response.Took + "ms and it has " + response.Total + " results.");
                Output.ShowResult(response.Documents);
                return;
            }

            if (response.OriginalException != null)
                Output.Throw("Exception occurred while processing the request.");

            if (response.ServerError != null)
                Output.Throw("error occurred in the server side of the process.");

            if (response.TerminatedEarly)
                Output.Throw("request terminated earlier than it was supposed to.");

            if (response.TimedOut)
                Output.Throw("request timed out!");
        }
    }
}
