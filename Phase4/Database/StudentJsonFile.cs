using System.Collections.Generic;
using System.Text.Json;
using Phase4.Models;

namespace Phase4.Database
{
    public class StudentJsonFile : JsonFile<List<Student>>
    {
        public StudentJsonFile(string filePath)
        {
            this.filePath = filePath;
        }

        protected override List<Student> DeserializeFile(string text)
        {
            var parsedFile = JsonSerializer.Deserialize<List<Student>>(text);
            return parsedFile;
        }
    }
}