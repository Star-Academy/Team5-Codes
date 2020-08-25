using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    class Program
    {

        private const string indexName = "index_66";
        private const string fileName = "people.json";
        private const string baseAddress = "http://localhost:9200/";

        static void Main(string[] args)
        {
            var items = ReadItemsFromFile<Person>(fileName);
            // await ConnectByHttpClientAsync(items);

            _ = ElasticSearch.GetClient();
            _ = new IndexHandler<Person>(items, indexName);

            var input = new InputReader().ReadInput();
            var processor = new ProcessInput();
            var processedInput = processor.Process(input);

            var queryHandler = new QueryHandler(indexName);

            var response = queryHandler.DoQuery(processedInput);

            if (ResponseValidator.Check((Nest.ResponseBase)response))
            {
                Output.Write("request took " + response.Took + "ms and it has " + response.Total + " results.");
                ShowResult(response.Documents);
            }
            else
                ResponseValidator.Validate((Nest.ResponseBase)response);
        }

        static List<T> ReadItemsFromFile<T>(string path)
        {
            var content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(content);
        }

        public static void ShowResult<T>(IReadOnlyCollection<T> result)
        {
            foreach (var item in result)
                Output.Write(item.ToString());
        }

        private static async System.Threading.Tasks.Task ConnectByHttpClientAsync(List<Person> items)
        {
            var httpClient = new MyHttpClient(baseAddress, indexName);
            await httpClient.ConnectAsync();
            await httpClient.PutRequestAsync();
            foreach (var item in items) {
                await httpClient.PostRequestAsync(item);
            }

        }
    }
}