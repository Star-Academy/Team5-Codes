using Elasticsearch.Net;
using Nest;
using Phase8;
using Phase8.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Phase9_API.Test
{
    public class ExceptionTest {
        [Fact]
        public void TimeoutExceptionTest () {
            var temp = new ResponseValidator();
            var imagniaryResponse = new TestResponse();
            Assert.Throws<TimeOutException>(() => ResponseValidator.Check(imagniaryResponse));
        }
    }
}

namespace Phase9_API.Test
{
    public class TestResponse : ISearchResponse<Person>
    {
        AggregateDictionary ISearchResponse<Person>.Aggregations => null;

        ClusterStatistics ISearchResponse<Person>.Clusters => null;

        IReadOnlyCollection<Person> ISearchResponse<Person>.Documents => null;

        IReadOnlyCollection<FieldValues> ISearchResponse<Person>.Fields => null;

        IReadOnlyCollection<IHit<Person>> ISearchResponse<Person>.Hits => null;

        IHitsMetadata<Person> ISearchResponse<Person>.HitsMetadata => null;

        double ISearchResponse<Person>.MaxScore => 0;

        long ISearchResponse<Person>.NumberOfReducePhases => 0;

        Profile ISearchResponse<Person>.Profile => null;

        string ISearchResponse<Person>.ScrollId => "";

        ShardStatistics ISearchResponse<Person>.Shards => null;

        ISuggestDictionary<Person> ISearchResponse<Person>.Suggest => null;

        bool ISearchResponse<Person>.TerminatedEarly => true;

        bool ISearchResponse<Person>.TimedOut => false;

        long ISearchResponse<Person>.Took => 0;

        long ISearchResponse<Person>.Total => 0;

        string IResponse.DebugInformation => null;

        bool IResponse.IsValid => false;

        Exception IResponse.OriginalException => null;

        ServerError IResponse.ServerError => null;

        IApiCallDetails IElasticsearchResponse.ApiCall { get; set; }

        bool IElasticsearchResponse.TryGetServerErrorReason(out string reason)
        {
            throw new NotImplementedException();
        }
    }
}