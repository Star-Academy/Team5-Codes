using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;

namespace Phase9_API.Test
{
    public class TestResponse<T> : ISearchResponse<T>
    {
        public AggregateDictionary Aggregations => throw new NotImplementedException();

        public ClusterStatistics Clusters => throw new NotImplementedException();

        public IReadOnlyCollection<T> Documents => throw new NotImplementedException();

        public IReadOnlyCollection<FieldValues> Fields => throw new NotImplementedException();

        public IReadOnlyCollection<IHit<T>> Hits => throw new NotImplementedException();

        public IHitsMetadata<T> HitsMetadata => throw new NotImplementedException();

        public double MaxScore => throw new NotImplementedException();

        public long NumberOfReducePhases => throw new NotImplementedException();

        public Profile Profile => throw new NotImplementedException();

        public string ScrollId => throw new NotImplementedException();

        public ShardStatistics Shards => throw new NotImplementedException();

        public ISuggestDictionary<T> Suggest => throw new NotImplementedException();

        public bool TerminatedEarly => throw new NotImplementedException();

        public bool TimedOut => throw new NotImplementedException();

        public long Took => throw new NotImplementedException();

        public long Total => throw new NotImplementedException();

        public string DebugInformation => throw new NotImplementedException();

        public bool IsValid => throw new NotImplementedException();

        public Exception OriginalException => throw new NotImplementedException();

        public ServerError ServerError => throw new NotImplementedException();

        public IApiCallDetails ApiCall { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool TryGetServerErrorReason(out string reason)
        {
            throw new NotImplementedException();
        }
    }
}