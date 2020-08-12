using System.Collections.Generic;
using System.Text.Json;
using Phase4.Models;

namespace Phase4.Database
{
    public class StudentJsonFile : JsonFile
    {
        public StudentJsonFile(string filePath)
        {
            this.filePath = filePath;
            Init();
        }

        protected override T DeserializeFile<T>(string text)
        {
            var parsedFile = JsonSerializer.Deserialize<List<Student>>(text);
            foreach (var student in parsedFile)
            {
                Student.AddStudent(student);
            }
            return (T)System.Convert.ChangeType(parsedFile, typeof(T));
        }
    }
}