using System;
using System.Collections.Generic;
using System.Net;
using Nest;

namespace Phase8 {
    class QueryHandler {
        public string ElasticIndexName { get; set; }
        public static ElasticClient Client { get; set; }

        public QueryHandler (string v) {
            ElasticIndexName = v;
        }

        public IReadOnlyCollection<Person> BoolQuerySample2 () {
            var response = Client.Search<Person> (s => s
                .Index (ElasticIndexName)
                .Query (q => q
                    .Bool (b => b
                        .Must (must => must
                            .Match (match => match
                                .Field (p => p.About)
                                .Query ("Labore"))))));

            return response.Documents;
        }
    }
}