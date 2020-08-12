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
            Init();
        }

<<<<<<< HEAD
        protected override T DeserializeFile<T>(string text)
=======
        protected override List<Student> DeserializeFile(string text)
>>>>>>> eaec350cad3a6d1c0aed157440235521ca041f68
        {
            var parsedFile = JsonSerializer.Deserialize<List<Student>>(text);
            foreach (var student in parsedFile)
            {
                Student.AddStudent(student);
            }
<<<<<<< HEAD
            return (T)System.Convert.ChangeType(parsedFile, typeof(T));
=======
            return parsedFile;
>>>>>>> eaec350cad3a6d1c0aed157440235521ca041f68
        }
    }
}