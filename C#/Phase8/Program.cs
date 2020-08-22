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
            var client = ElasticSearch.GetClient();
            var indexHandler = new IndexHandler();
            var items = ReadItemsFromFile<Person>("people.json");
            indexHandler.AddDocToIndex<Person>(IndexName, items);
        }

        static List<T> ReadItemsFromFile<T>(string path)
        {
            var content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(content);
        }
    }
}
