using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Phase8 {
    public class MyHttpClient {
        private readonly HttpClient client = new HttpClient ();
        private readonly string indexName;
        private readonly string baseAddress; 


        public MyHttpClient(string baseAddress, string indexName)
        {
            this.baseAddress = baseAddress;
            this.indexName = indexName;
        }

        public async Task PutRequestAsync () {
            var response = await client.PutAsync(baseAddress + indexName + "/", null);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine ("PUT request response:\n" + responseBody);
        }

        public async Task ConnectAsync () {
            try {
                HttpResponseMessage response = await client.GetAsync (baseAddress);
                response.EnsureSuccessStatusCode ();
                string responseBody = await response.Content.ReadAsStringAsync ();

                Console.WriteLine (responseBody);
            } catch (HttpRequestException e) {
                Console.WriteLine ("\nException Caught!\nMessage :{0} ", e.Message);
            }
        }

        public async Task GetRequestAsync () {
            var request = new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new Uri (baseAddress),
            };

            var response = await client.SendAsync (request).ConfigureAwait (false);
            response.EnsureSuccessStatusCode ();

            var responseBody = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
            Console.WriteLine ("GET request response:\n" + responseBody);
        }

        public async Task PostRequestAsync<T> (T item) where T : class {
            var uri = new Uri(baseAddress + indexName + "/_doc");
            var contetnt = JsonSerializer.Serialize(item);

            Console.WriteLine(contetnt);

            var response = await client.PostAsync (uri, null);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine ("POST request response:\n" + responseBody);
        }
    }
}