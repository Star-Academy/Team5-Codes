using Nest;
using System.Collections.Generic;
using System.Linq;

namespace Phase8
{
    class QueryHandler
    {
        private const string field = "about";
        public string ElasticIndexName { get; set; }
        public static ElasticClient Client { get; set; }

        public QueryHandler(string indexName)
        {
            Client = ElasticSearch.GetClient();
            ElasticIndexName = indexName;
        }
        public ISearchResponse<Person> DoQuery(Dictionary<string, List<string>> processedInput)
        {
            var query1 = new BoolQuery
            {
                Must = new List<QueryContainer> { }
            };

            query1.Must.Append(
                new MatchQuery
                {
                    Field = field,
                    Query = "Labore"
                }
            );

            var query = new MatchAllQuery
            {
                //...
                Name = "Match All query",

            };

            var response = Client.Search<Person>(s => s
               .Index(ElasticIndexName)
               .Query(q => query)
            );

            return response;
        }

        private BoolQuery CreateOrQuery(List<string> allTokens)
        {
            var shouldList = new List<QueryContainer>();

            foreach (var token in allTokens)
            {
                shouldList.Add(new MatchQuery
                {
                    Field = field,
                    Query = token,
                    Analyzer = "standard",
                    Fuzziness = Fuzziness.Auto,
                });
            }

            BoolQuery query = new BoolQuery
            {
                Should = shouldList
            };

            return query;
        }
    }
}