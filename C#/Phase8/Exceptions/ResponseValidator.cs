using Nest;
using Phase8.Exceptions;

namespace Phase8
{
    public class ResponseValidator
    {
        public static void Validate(ISearchResponse<Person> response)
        {
            if (response is ISearchResponse<Person> res)
            {
                Output.Write("only " + res.Total + " results found");
                if (res.TerminatedEarly)
                    throw new RequestTermination("request terminated earlier than it was supposed to.");

                if (res.TimedOut)
                    throw new TimeOutException("request timed out!");
            }

            if (response.OriginalException != null)
                throw new BuildException("Exception occurred while processing the request.");

            if (response.ServerError != null)
                throw new ServerException("error occurred from the server side of the process.");

        }

        public static bool Check(ResponseBase response)
        {
            return response.IsValid && response.ApiCall.Success;
        }
    }
}
