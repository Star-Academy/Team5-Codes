using Nest;
using Phase8.Modules;

namespace Phase8.Nest
{
    public interface ISearchEngine
    {
         public ISearchResponse<Person> GenerateResponse(QuerySample query);
    }
}