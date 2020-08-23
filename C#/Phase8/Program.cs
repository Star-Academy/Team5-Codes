using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8 {
    class Program {

        private const string IndexName = "index_1";
        private const string FileName = "people.json";

        static void Main (string[] args) {
            var client = ElasticSearch.GetClient ();
            var indexHandler = new IndexHandler<Person> (ReadItemsFromFile<Person> (FileName), IndexName);
            
            //var response = client.Cat.Indices();
            //Console.WriteLine(response.Records.Count);

            var input = new InputReader ().ReadInput ();
            var processor = new ProcessInput ();
            var processedInput = processor.Process (input);

            var queryHandler = new QueryHandler (IndexName);

            ShowResult(queryHandler.DoQuery(processedInput).Documents);
            ResponseValidator.Validate (queryHandler.DoQuery (processedInput));
        }

        static List<T> ReadItemsFromFile<T> (string path) {
            var content = File.ReadAllText (path);
            return JsonSerializer.Deserialize<List<T>> (content);
        }

        public static void ShowResult<T> (IReadOnlyCollection<T> result) {
            foreach (var item in result) {
                Console.WriteLine (item);
            }
        }
    }
}