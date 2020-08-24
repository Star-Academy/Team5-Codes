using Nest;
using System.Collections.Generic;

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

            var query = new BoolQuery
            {
                Must = setListInQuery(processedInput["and"]),
                MustNot = setListInQuery(processedInput["not"]),
                Should = setListInQuery(processedInput["or"]),
            };

            var response = Client.Search<Person>(s => s
               .Index(ElasticIndexName)
               .Query(q => query)
            );

            return response;
        }

        private List<QueryContainer> setListInQuery(List<string> tokens)
        {
            var mustList = new List<QueryContainer>();
            foreach (var item in tokens)
            {
                mustList.Add(new MatchQuery
                {
                    Field = field,
                    Query = item,
                });
            }
            return mustList;
        }
    }
}