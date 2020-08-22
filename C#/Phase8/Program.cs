using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    class Program
    {

        private const string IndexName = "my-indeex";
        private const string FileName = "people.json";
        static void Main(string[] args)
        {
            var client = ElasticSearch.GetClient();
            ReadItemsFromFile<Person>(FileName);
            QueryHandler.Client = client;
            QueryHandler handler = new QueryHandler(IndexName);
            var indexHandler = new IndexHandler();
            var items = ReadItemsFromFile<Person>(FileName);
            indexHandler.AddDocToIndex<Person>(IndexName, items);
        }

        static List<T> ReadItemsFromFile<T>(string path)
        {
            var content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(content);
        }
    }
}