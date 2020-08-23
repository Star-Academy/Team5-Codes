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

        public IReadOnlyCollection<Person> BoolQuery (Dictionary<string, List<string>> processedInput) {
            var response = Client.Search<Person> (s => s
                .Index (ElasticIndexName)
                .Query (q => q
                    .Bool (b => b
                        // .Must (must => must
                        //     .Match (match => match
                        //         .Field ("email")
                        //         .Query ("lolajefferson@buzzmaker.com")
                        //     )
                        // )
                        .MustNot (mustNot => mustNot
                            .Match (match => match
                                .Field ("email")
                                .Query ("lolajeson@buzzmaker.com")
                            )
                        )
                        .Should (should => should
                            .Match (match => match
                                .Field ("email")
                                .Query ("lolajeffen@buzzmaker.com")
                            )
                        )
                        
                    )
                )
            );
            return response.Documents;
        }
    }
}