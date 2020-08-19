using Nest;
using System;

namespace Phase8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            connectionSettings.EnableDebugMode();
            ElasticClient client = new ElasticClient(connectionSettings);
            var test = client.Ping();
        }
    }
}
