using Nest;
using System.Collections.Generic;

namespace Phase8
{
    class QueryHandler
    {
        private const string Field = "about";
        public string ElasticIndexName { get; set; }
        public static ElasticClient Client { get; set; }

        public QueryHandler(string indexName)
        {
            Client = ElasticSearch.GetClient();
            ElasticIndexName = indexName;
        }

        public ISearchResponse<Person> DoQuery(Dictionary<string, List<string>> processedInput)
        {
            QueryContainer query = new BoolQuery
            {
                Must = new List<QueryContainer> {
                    new BoolQuery{
                        Must = SetListInQuery(processedInput["and"], false)
                    },
                    new BoolQuery{
                        Should = SetListInQuery(processedInput["or"], true)
                    }
                },
                MustNot = SetListInQuery(processedInput["not"], true)
            };

            var response = Client.Search<Person>(s => s
               .Index(ElasticIndexName)
               .Query(q => query)
            );

            return response;
        }

        private List<QueryContainer> SetListInQuery(List<string> tokens, bool hasSign)
        {
            var mustList = new List<QueryContainer>();
            foreach (var item in tokens)
            {
                mustList.Add(
                    new MatchQuery
                    {
                        Field = Field,
                        Query = item.Substring(hasSign ? 1 : 0),
                    });
            }
            return mustList;
        }
    }
}