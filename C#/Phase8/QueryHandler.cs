using Nest;
using System.Collections.Generic;
using System.Net;

namespace Phase8
{
    class QueryHandler
    {
        public string ElasticIndexName { get; set; }
        public static ElasticClient Client { get; set; }

        public QueryHandler(string v)
        {
            ElasticIndexName = v;
        }

        public void BoolQuerySample1()
        {
            QueryContainer query = new BoolQuery
            {
                Must = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = "about",
                        Query = "Labore"
                    }
                }
            };
            var response = Client.Search<Dictionary<string, object>>(s => s
                .Index(ElasticIndexName)
                .Query(q => query));
        }

        public void BoolQuerySample2()
        {
            var response = Client.Search<Person>(s => s
                .Index(ElasticIndexName)
                .Query(q => q
                    .Bool(b => b
                        .Must(must => must
                            .Match(match => match
                                .Field(p => p.About)
                                .Query("Labore"))))));
        }

        public static void MatchAllQuerySample1()
        {
            Client.Search<Person>(s => s.
            Query(query => query
            .MatchAll()));
            
        }

    }
}
