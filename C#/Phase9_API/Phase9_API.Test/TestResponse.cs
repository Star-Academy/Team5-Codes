using Elasticsearch.Net;
using Nest;
using Phase8;
using System;
using System.Collections.Generic;

namespace Phase9_API.Test
{
    public class TestResponse : ISearchResponse<Person>
    {
        readonly bool[] forThrow = { false, false, false, false };
        public TestResponse(int type)
        {
            forThrow[type] = true;
        }
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

        bool ISearchResponse<Person>.TerminatedEarly => forThrow[0];

        bool ISearchResponse<Person>.TimedOut => forThrow[1];

        long ISearchResponse<Person>.Took => 0;

        long ISearchResponse<Person>.Total => 0;

        string IResponse.DebugInformation => null;

        bool IResponse.IsValid => false;

        Exception IResponse.OriginalException => forThrow[2] ? new Exception() : null;

        ServerError IResponse.ServerError => forThrow[3] ? new ServerError(new Error(), 404) : null;

        IApiCallDetails IElasticsearchResponse.ApiCall { get; set; }

        bool IElasticsearchResponse.TryGetServerErrorReason(out string reason)
        {
            throw new NotImplementedException();
        }
    }
}