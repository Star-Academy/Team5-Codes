using Nest;
using System.Collections.Generic;

namespace Phase8
{
    class QueryHandler
    {
        private const string Field = "age";
        public string ElasticIndexName { get; set; }
        public static ElasticClient Client { get; set; }

        public QueryHandler(string indexName)
        {
            Client = ElasticSearch.GetClient();
            ElasticIndexName = indexName;
        }

        public ISearchResponse<Person> DoQuery(Dictionary<string, List<string>> processedInput)
        {

            var query = new BoolQuery
            {
                Should = new List<QueryContainer> {
                    new BoolQuery{
                        Must = SetListInQuery(processedInput["and"])
                    },
                    new BoolQuery{
                        Should = SetListInQuery(processedInput["or"]),
                    }
                },
                MustNot = SetListInQuery(processedInput["not"]),
            };

            var response = Client.Search<Person>(s => s
               .Index(ElasticIndexName)
               .Query(q => query)
               .Size(200)
            );

            return response;
        }

        private List<QueryContainer> SetListInQuery(List<string> tokens)
        {
            var mustList = new List<QueryContainer>();
            foreach (var item in tokens)
            {
                mustList.Add(new MatchQuery
                {
                    Field = Field,
                    Query = item,
                });
            }
            return mustList;
        }
    }
}