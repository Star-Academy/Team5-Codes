using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var q = new BoolQuery();


            List<BoolQuery> queries = new List<BoolQuery>
            {
                CreateOrQuery(processedInput["and"])
            };
            BoolQuery positiveResult = new BoolQuery();

            var response = Client.Search<Person> (s => s
                .Index (ElasticIndexName)
                .Query (q => queries[0])
            );

            return response.Documents;
        }

        private BoolQuery CreateOrQuery (List<string> allTokens) {
            var shouldList = new List<QueryContainer>();

            foreach (var token in allTokens) {
                shouldList.Add (new MatchQuery {
                    Field = field,
                    Query = token,
                    Analyzer = "standard",
                    Fuzziness = Fuzziness.Auto,
                });
            }
            
            BoolQuery query = new BoolQuery {
                Should = shouldList
            };  

            return query;
        }
    }
}