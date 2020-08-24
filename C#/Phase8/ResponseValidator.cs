using Nest;

namespace Phase8
{
    class ResponseValidator
    {
        public static void Validate(ResponseBase response)
        {
            if (response is ISearchResponse<Person>)
            {
                var res = (ISearchResponse<Person>)response;
                Output.Write("only " + res.Total + " results found");
                if (res.TerminatedEarly)
                    Output.Throw("request terminated earlier than it was supposed to.");

                if (res.TimedOut)
                    Output.Throw("request timed out!");
            }

            if (response.OriginalException != null)
                Output.Throw("Exception occurred while processing the request.");

            if (response.ServerError != null)
                Output.Throw("error occurred in the server side of the process.");

        }

        public static bool Check(ResponseBase response)
        {
            return response.IsValid && response.ApiCall.Success;
        }
    }
}
