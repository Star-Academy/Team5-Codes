using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Phase8 {
    public class MyHttpClient {
        private readonly HttpClient client = new HttpClient ();

        public async Task Run () {
            await ConnectAsync ();
            await GetRequestAsync ();
            await PutRequestAsync ();
            await PostRequestAsync ();
        }

        private async Task PutRequestAsync () {
            var response = await client.PostAsync ("http://localhost:9200/z-index", null);
            var responseString = await response.Content.ReadAsStringAsync ();

            Console.WriteLine ("PUT request response:\n" + response);
        }

        private async Task ConnectAsync () {
            try {
                HttpResponseMessage response = await client.GetAsync ("http://localhost:9200");
                response.EnsureSuccessStatusCode ();
                string responseBody = await response.Content.ReadAsStringAsync ();

                Console.WriteLine (responseBody);
            } catch (HttpRequestException e) {
                Console.WriteLine ("\nException Caught!\nMessage :{0} ", e.Message);
            }
        }

        private async Task GetRequestAsync () {
            var request = new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new Uri ("http://localhost:9200"),
            };

            var response = await client.SendAsync (request).ConfigureAwait (false);
            response.EnsureSuccessStatusCode ();

            var responseBody = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
            Console.WriteLine ("GET request response:\n" + responseBody);
        }

        private async Task PostRequestAsync () {
            var values = new Dictionary<string, string> { { "thing1", "hello" },
                    { "thing2", "world" }
                };

            var content = new FormUrlEncodedContent (values);
            var response = await client.PostAsync ("http://localhost:9200/f-index", content);
            var responseString = await response.Content.ReadAsStringAsync ();

            Console.WriteLine ("POST request response:\n" + response);
        }
    }
}