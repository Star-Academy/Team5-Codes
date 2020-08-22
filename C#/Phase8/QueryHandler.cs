using Nest;
using System;
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
                .Query(q => query)
                );
            Console.WriteLine(response);
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
            Console.WriteLine(response);
        }

        public void MatchAllQuerySample1()
        {
            var response = Client.Search<Person>(s => s
                .Index(ElasticIndexName)
                .MatchAll()
            );
            Console.WriteLine(response);
        }

        public void MatchQuerySample1()
        {
            var response = Client.Search<Person>(s => s
                .Index(ElasticIndexName)
                .Query(query => query
                    .Match(match => match
                       .Field(p => p.About)
                       .Query("Labore"))));
            Console.WriteLine(response);
        }

        public void FuzzyQuerySample1()
        {
            var response = Client.Search<Person>(s => s
            .Index(ElasticIndexName)
            .Query(query => query
                .Fuzzy(c => c
                    .Name("Fuzzy Query Sample 1")
                    .Field(p => p.Name)
            .Fuzziness(Fuzziness.Auto))));

            Console.WriteLine(response);
        }

        public void TermQuerySample1()
        {
            var response = Client.Search<Person>(s => s.
            Index(ElasticIndexName)
            .Query(query => query
            .Term(c => c
                .Name("Term Query Sample1")
                .Field(p => p.About)
                .Value("Labore"))));
            Console.WriteLine(response);
        }

        public void TermQueryVerbatimSample()
        {
            var response = Client.Search<Person>(s => s.
            Index(ElasticIndexName)
            .Query(query => query
            .Term(c => c
                .Verbatim()
                .Field(p => p.About)
                .Value(string.Empty))));
            Console.WriteLine(response);
        }

        public void TermsQuerySample1()
        {
            var response = Client.Search<Person>(s => s.
            Index(ElasticIndexName)
            .Query(query => query
            .Terms(c => c
                .Name("Terms Query Sample1")
                .Field(p => p.About)
                .Terms("Labore", "salam", "ishalla"))));
            Console.WriteLine(response);
        }

    }
}
