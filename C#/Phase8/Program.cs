using Nest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Phase8
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD

            
            ReadPersons("people.json");
=======
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            // connectionSettings.EnableDebugMode();
            ElasticClient client = new ElasticClient(connectionSettings);
            var test = client.Ping();
            Console.WriteLine(test);
            ReadPersons(@"..\..\..\people.json");
>>>>>>> ffde34a06b861be0f7c678bda1010821e68b2f66
        }

        static List<Person> ReadPersons(string path)
        {
            var content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Person>>(content);
        }
    }
}
