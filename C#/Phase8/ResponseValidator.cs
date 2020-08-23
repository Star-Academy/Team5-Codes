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
                Console.WriteLine("request took " + response.Took + "ms and it has " + response.Total + "results.");
                Program.ShowResult(response.Documents);
                return;
            } 
            if (response.OriginalException != null)
                Console.WriteLine("Exception occured while processing the request.");

            if (response.ServerError != null)
                Console.WriteLine("error occured in the server side of the process.");

            if (response.TerminatedEarly)
                Console.WriteLine("request terminated earlier than it was supposed to.");

            if (response.TimedOut)
                Console.WriteLine("request timed out!");
        }
    }
}
