using Nest;
using Phase8.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    public class Program
    {

        private const string indexName = "index";
        private const string fileName = "people.json";
        private const string baseAddress = "http://localhost:9200/";

        static void Main(string[] args)
        {
            var items = ReadItemsFromFile<Person>();
            // await ConnectByHttpClientAsync(items);
            var response = GenerateResponse(args, items);

            if (ResponseValidator.Check((Nest.ResponseBase)response))
            {
                Output.Write("request took " + response.Took + "ms and it has " + response.Total + " results.");
                ShowResult(response.Documents);
                return;
            }
            try
            {
                ResponseValidator.Validate((Nest.ResponseBase)response);
            }
            catch (RequestTermination ex)
            {
                Console.WriteLine("request terminated in your machine :( .");
            }
            catch (TimeOutException ex)
            {
                Console.WriteLine("request lost :( .");
            }
            catch (BuildException ex)
            {
                Console.WriteLine("request didn't build successfully.");
            }
            catch (ServerException ex)
            {
                Console.WriteLine("server didn't respond to us.");
            }
        }

        public static ISearchResponse<Person> GenerateResponse(string[] args, List<Person> items)
        {
            _ = ElasticSearch.GetClient();
            _ = new IndexHandler<Person>(items, indexName);
            var input = new ConsoleReader(args).ReadInput();
            var processor = new ProcessInput();
            var processedInput = processor.Process(input);

            var queryHandler = new QueryHandler(indexName);

            var response = queryHandler.DoQuery(processedInput);
            return response;
        }

        public static List<T> ReadItemsFromFile<T>()
        {
            var content = File.ReadAllText(fileName);
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
