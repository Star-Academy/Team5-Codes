using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            // connectionSettings.EnableDebugMode();
            ElasticClient client = new ElasticClient(connectionSettings);
            var test = client.Ping();
            
            var content = File.ReadAllText("people.json");
            JsonSerializer.Deserialize<List<Person>>(content);
        }
    }
}
