using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    class Program
    {

        private const string IndexName = "index_1";
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            //connectionSettings.EnableDebugMode();
            ElasticClient client = new ElasticClient(connectionSettings);
            var test = client.Ping();
            Console.WriteLine(test);
            ReadPersons(@"..\..\..\people.json");
            QueryHandler.Client = client;
            QueryHandler handler = new QueryHandler("my-index");
            var indexHandler = new IndexHandler();
            indexHandler.CreateIndex("my-index");
        }

        static List<Person> ReadPersons(string path)
        {
            var content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Person>>(content);
        }
    }
}
