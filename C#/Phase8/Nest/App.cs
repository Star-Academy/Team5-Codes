using Nest;
using Phase8.Exceptions;
using Phase8.Nest;
using System;
using System.Collections.Generic;

namespace Phase8
{
    public class App
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var searchEngine = new SearchEngine();
            // await searchEngine.ConnectByHttpClientAsync(items);
            var response = searchEngine.GenerateResponse();
            if (ResponseValidator.Check((ResponseBase)response))
            {
                Output.Write("request took " + response.Took + "ms and it has " + response.Total + " results.");
                ShowResult(response.Documents);
                return;
            }
            try
            {
                ResponseValidator.Validate(response);
            }
            catch (RequestTermination)
            {
                Console.WriteLine("request terminated in your machine :( .");
            }
            catch (TimeOutException)
            {
                Console.WriteLine("request lost :( .");
            }
            catch (BuildException)
            {
                Console.WriteLine("request didn't build successfully.");
            }
            catch (ServerException)
            {
                Console.WriteLine("server didn't respond to us.");
            }
        }
        public static void ShowResult<T>(IReadOnlyCollection<T> result)
        {
            foreach (var item in result)
                Output.Write(item.ToString());
        }


    }
}
