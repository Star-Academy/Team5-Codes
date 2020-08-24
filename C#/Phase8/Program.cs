using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    class Program
    {

        private const string IndexName = "index_1";
        private const string FileName = "people.json";

        static void Main(string[] args)
        {
            _ = ElasticSearch.GetClient();
            _ = new IndexHandler<Person>(ReadItemsFromFile<Person>(FileName), IndexName);

            var input = new InputReader().ReadInput();
            var processor = new ProcessInput();
            var processedInput = processor.Process(input);

            var queryHandler = new QueryHandler(IndexName);

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
    }
}