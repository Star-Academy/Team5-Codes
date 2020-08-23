using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    class Program
    {

        private const string IndexName = "my-index";
        private const string FileName = "people.json";
        
        static void Main(string[] args)
        {
            var client = ElasticSearch.GetClient();
            var indexHandler = new IndexHandler<Person>();
            var items = ReadItemsFromFile<Person>(FileName);   

            QueryHandler.Client = client;
            QueryHandler handler = new QueryHandler(IndexName);
            
            indexHandler.CreateIndex(IndexName);
            indexHandler.AddDocToIndex(IndexName, items);
            
            handler.FuzzyQuerySample1();
            handler.TermQuerySample1();

        }

        static List<T> ReadItemsFromFile<T>(string path)
        {
            var content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(content);
        }
    }
}