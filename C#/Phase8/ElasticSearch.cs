using Nest;
using System;

namespace Phase8
{
    public class ElasticSearch
    {
        private static readonly ElasticClient client;

        static ElasticSearch()
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            client = new ElasticClient(connectionSettings);
        }

        static public ElasticClient GetClient()
        {
            return client;
        }
    }
}