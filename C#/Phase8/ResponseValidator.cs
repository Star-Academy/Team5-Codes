using Nest;

namespace Phase8
{
    class ResponseValidator
    {
        public static void Validate(ISearchResponse<Person> response)
        {
            if (response.ApiCall.Success)
            {
                Program.ShowResult(response.Documents);
                return;
            } 

        }
    }
}
