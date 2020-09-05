using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Nest;
using Phase8.Modules;

namespace Phase8.Nest
{
    public class SearchEngine : ISearchEngine
    {
        private const string indexName = "index";
        private const string baseAddress = "http://localhost:9200/";
        private const string fileName = "people.json";
        public ISearchResponse<Person> GenerateResponse(QuerySample query = null)
        {
            string[] args = (query == null ? new string[0] : new string[] { query.Text });
            var items = ReadItemsFromFile<Person>();
            _ = ElasticSearch.GetClient();
            _ = new IndexHandler<Person>(items, indexName);
            var input = new ConsoleReader(args).ReadInput();
            var processor = new ProcessInput();
            var processedInput = processor.Process(input);

            var queryHandler = new QueryHandler(indexName);

            var response = queryHandler.DoQuery(processedInput);
            return response;
        }

        public List<T> ReadItemsFromFile<T>()
        {
            var content = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<T>>(content);
        }

        public async System.Threading.Tasks.Task ConnectByHttpClientAsync(List<Person> items)
        {
            var httpClient = new MyHttpClient(baseAddress, indexName);
            await httpClient.ConnectAsync();
            await httpClient.PutRequestAsync();
            foreach (var item in items)
            {
                await httpClient.PostRequestAsync(item);
            }

        }
    }
}