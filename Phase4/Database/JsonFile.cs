using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Phase4.Models;

namespace Phase4.Database
{
    public class JsonFile
    {
        private string filePath;

        public JsonFile(string filePath)
        {
            this.filePath = filePath;
            Init();
        }

        private void Init()
        {
            string text = ReadFile(filePath);
            deserializeFile(text);
        }

        private string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        private void deserializeFile(string text)
        {
            var parsedFile = JsonSerializer.Deserialize<List<Student>>(text);
            foreach (var student in parsedFile)
            {
                Student.AddStudent(student);
            }
        }
    }
}