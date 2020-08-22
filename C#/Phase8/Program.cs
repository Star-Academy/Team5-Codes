using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    class Program
    {

        private const string IndexName = "index_1";
        static void Main(string[] args)
        {
            var client = ElasticSearch.GetClient();
            var indexHandler = new IndexHandler();
            indexHandler.CreateIndex();
        }

        static List<Person> ReadPersons(string path)
        {
            var content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Person>>(content);
        }
    }
}
