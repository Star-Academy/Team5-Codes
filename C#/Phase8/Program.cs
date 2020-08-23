using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    class Program
    {

        private const string IndexName = "index_2";
        private const string FileName = "people.json";

        static void Main(string[] args)
        {
            var client = ElasticSearch.GetClient();
            var indexHandler = new IndexHandler<Person>();
            var items = ReadItemsFromFile<Person>(FileName);
            // indexHandler.CreateIndex(IndexName);
            // indexHandler.AddDocToIndex(IndexName, items);

            var input = new InputReader().ReadInput();
            var processor = new ProcessInput();
            var processedInput = processor.Process(input);

            QueryHandler queryHandler = new QueryHandler(IndexName);
            ShowResult(queryHandler.BoolQuery(processedInput));

        }

        static List<T> ReadItemsFromFile<T>(string path)
        {
            var content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(content);
        }

        static void ShowResult<T>(IReadOnlyCollection<T> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}