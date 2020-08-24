using Nest;
using System.Collections.Generic;

namespace Phase8
{
    class QueryHandlerTest
    {
        public string ElasticIndexName { get; set; }
        public static ElasticClient Client { get; set; }

        public QueryHandlerTest(string v)
        {
            Client = ElasticSearch.GetClient();
            ElasticIndexName = v;
        }

        public IReadOnlyCollection<Dictionary<string, object>> BoolQuerySample1()
        {
            QueryContainer query = new BoolQuery
            {
                Must = new List<QueryContainer> {
                    new MatchQuery {
                        Field = "about",
                        Query = "Labore"
                    }
                }
            };
            var response = Client.Search<Dictionary<string, object>>(s => s
                   .Index(ElasticIndexName)
                   .Query(q => query)
                );

            return response.Documents;
        }

        public IReadOnlyCollection<Person> BoolQuerySample2()
        {
            var response = Client.Search<Person>(s => s
               .Index(ElasticIndexName)
               .Query(q => q
                  .Bool(b => b
                     .Must(must => must
                        .Match(match => match
                           .Field(p => p.About)
                           .Query("Labore"))))));

            return response.Documents;
        }

        public IReadOnlyCollection<Person> MatchAllQuerySample1()
        {
            var response = Client.Search<Person>(s => s
               .Index(ElasticIndexName)
               .MatchAll()
            );

            return response.Documents;
        }

        public IReadOnlyCollection<Person> MatchQuerySample1()
        {
            var response = Client.Search<Person>(s => s
               .Index(ElasticIndexName)
               .Query(query => query
                  .Match(match => match
                     .Field(p => p.About)
                     .Query("Labore"))));

            return response.Documents;
        }

        public IReadOnlyCollection<Person> FuzzyQuerySample1()
        {
            var response = Client.Search<Person>(s => s
               .Index(ElasticIndexName)
               .Query(query => query
                  .Fuzzy(c => c
                     .Name("Fuzzy Query Sample 1")
                     .Field(p => p.Name)
                     .Fuzziness(Fuzziness.Auto))));
            return response.Documents;
        }

        public IReadOnlyCollection<Person> TermQuerySample1()
        {
            var response = Client.Search<Person>(s => s.Index(ElasticIndexName)
               .Query(query => query
                  .Term(c => c
                     .Name("Term Query Sample1")
                     .Field(p => p.About)
                     .Value("Labore"))));

            return response.Documents;
        }

        public IReadOnlyCollection<Person> TermQueryVerbatimSample()
        {
            var response = Client.Search<Person>(s => s.Index(ElasticIndexName)
               .Query(query => query
                  .Term(c => c
                     .Verbatim()
                     .Field(p => p.About)
                     .Value(string.Empty))));

            return response.Documents;
        }

        public IReadOnlyCollection<Person> TermsQuerySample1()
        {
            var response = Client.Search<Person>(s => s.Index(ElasticIndexName)
               .Query(query => query
                  .Terms(c => c
                     .Name("Terms Query Sample1")
                     .Field(p => p.About)
                     .Terms("Labore", "salam", "ishalla"))));

            return response.Documents;
        }

        public IReadOnlyCollection<Person> TermsQueryVerbatimSample()
        {
            var response = Client.Search<Person>(s => s.Index(ElasticIndexName)
               .Query(query => query
                  .Terms(c => c
                     .Verbatim()
                     .Field(p => p.About)
                     .Terms(new string[] { }))));

            return response.Documents;
        }

        public IReadOnlyCollection<Person> RangeQuerySample1()
        {
            var response = Client.Search<Person>(s => s.Index(ElasticIndexName)
               .Query(query => query
                  .Range(c => c
                     .Field(p => p.Age)
                     .LessThan(20)
                     .GreaterThan(15))));

            return response.Documents;
        }

        public IReadOnlyCollection<Person> GeoDistanceQuerySample1()
        {
            var response = Client.Search<Person>(s => s.Index(ElasticIndexName)
               .Query(query => query
                  .GeoDistance(g => g
                     .Name("Geo Distance Query Sample 1")
                     .Field(p => p.Location)
                     .DistanceType(GeoDistanceType.Arc)
                     .Location(0, 0)
                     .Distance("100m")
                     .ValidationMethod(GeoValidationMethod.IgnoreMalformed))));

            return response.Documents;
        }

        public IReadOnlyCollection<Person> MultiMatchQuerySample1()
        {
            var response = Client.Search<Person>(s => s.Index(ElasticIndexName)
               .Query(query => query
                  .MultiMatch(c => c
                     .Name("MultiMatch Query Sample 1")
                     .Fields(f => f.Field(p => p.About).Field(p => p.Name))
                     .Query("Labore")
                     .Analyzer("standard")
                     .Fuzziness(Fuzziness.Auto)
                     .PrefixLength(2)
                     .MinimumShouldMatch(1)
                     .FuzzyRewrite(MultiTermQueryRewrite.ConstantScoreBoolean)
                     .ZeroTermsQuery(ZeroTermsQuery.All)
                     .AutoGenerateSynonymsPhraseQuery(false)
                  )));

            return response.Documents;
        }

        public IReadOnlyCollection<Person> TermsAggregationQuerySample1()
        {
            var response = Client.Search<Person>(s => s.Index(ElasticIndexName)
               .Aggregations(a => a
                  .Terms("ages", avg => avg
                     .Field(f => f.Age)
                     .MinimumDocumentCount(2)
                     .Size(5)
                     .ShardSize(1000)
                     .ExecutionHint(TermsAggregationExecutionHint.Map)
                     .Missing("n/a")
                     .Order(o => o
                        .KeyAscending()
                        .CountDescending())
                  ))
            );
            return response.Documents;
        }

    }
}