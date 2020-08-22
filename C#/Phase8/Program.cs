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

            
            ReadPersons("people.json");
        }

        static List<Person> ReadPersons(string path)
        {
            var content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Person>>(content);
        }
    }
}
