using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Nest;

namespace Phase8 {
    class QueryHandler {
        private const string field = "about";
        public string ElasticIndexName { get; set; }
        public static ElasticClient Client { get; set; }

        public QueryHandler (string indexName) {
            Client = ElasticSearch.GetClient ();
            ElasticIndexName = indexName;
        }

        public IReadOnlyCollection<Person> DoQuery (Dictionary<string, List<string>> processedInput) {
            var query1 = new BoolQuery {
                Must = new List<QueryContainer> { }
            };

            query1.Must.Append (
                new MatchQuery {
                    Field = field,
                    Query = "Labore"
                }
            );

            var query = new MatchAllQuery {
                
            }

            var response = Client.Search<Person> (s => s
                .Index (ElasticIndexName)
                .Query (q => query)
            );

            return response.Documents;
        }
    }
}