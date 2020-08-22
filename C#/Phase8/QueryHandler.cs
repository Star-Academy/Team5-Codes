using Nest;
using System.Collections.Generic;
using System.Net;

namespace Phase8
{
    class QueryHandler
    {

        public static ElasticClient Client { get; set; }
        public static void BoolQuerySample1()
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
                .Index("my-index")
                .Query(q => query));
        }

        public static void BoolQuerySample2()
        {
            var response = Client.Search<Person>(s => s
                .Index("my-index")
                .Query(q => q
                    .Bool(b => b
                        .Must(must => must
                            .Match(match => match
                                .Field(p => p.About)
                                .Query("Labore"))))));
        }

        public static void MatchQuerySample1()
        {
            Client.Search<Person>(s => s.
            Query(query => query
            .MatchAll()));
        }

    }
}
