using System;
using System.Collections.Generic;
using System.Net;
using Nest;

namespace Phase8 {
    class QueryHandler {
        public string ElasticIndexName { get; set; }
        public static ElasticClient Client { get; set; }

        public QueryHandler (string indexName) {
            Client = ElasticSearch.GetClient ();
            ElasticIndexName = indexName;
        }

        public IReadOnlyCollection<Person> DoQuery (Dictionary<string, List<string>> processedInput) {
            var response = Client.Search<Person> (s => s
                .Index (ElasticIndexName)
                .Query (q => CreateQuery(processedInput)
                )
                );
            return response.Documents;
        }

        private QueryContainer CreateQuery (Dictionary<string, List<string>> processedInput) {
            QueryContainer query = new BoolQuery {
                Must = new List<QueryContainer> {
                new MatchQuery {
                Field = "about",
                Query = "Labore"
                }
                }
            };
            return query;
        }
    }
}