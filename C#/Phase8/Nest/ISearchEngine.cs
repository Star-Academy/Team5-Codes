using Nest;

namespace Phase8.Nest
{
    public interface ISearchEngine
    {
         public ISearchResponse<Person> GenerateResponse(string[] args);
    }
}