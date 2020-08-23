using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Nest;

namespace Phase8 {
    class QueryHandler {
        private const string field = "age";
        public string ElasticIndexName { get; set; }
        public static ElasticClient Client { get; set; }

        public QueryHandler (string indexName) {
            Client = ElasticSearch.GetClient ();
            ElasticIndexName = indexName;
        }

        public IReadOnlyCollection<Person> DoQuery (Dictionary<string, List<string>> processedInput) {
            List<BoolQuery> queries = new List<BoolQuery>();
            queries.Add (CreateOrQuery (processedInput["or"]));
            BoolQuery positiveResult = new BoolQuery();

            var response = Client.Search<Person> (s => s
                .Index (ElasticIndexName)
                .Query (q => queries[0])
            );

            return response.Documents;
        }

        private BoolQuery CreateOrQuery (List<string> allTokens) {
            BoolQuery query = new BoolQuery {
                Should = new List<QueryContainer> { }
            };

            foreach (var token in allTokens) {
                query.Should.Append (new MatchQuery {
                    Field = field,
                    Query = token,
                    Analyzer = "standard",
                    Fuzziness = Fuzziness.Auto,
                });
            }

            return query;
        }
    }
}