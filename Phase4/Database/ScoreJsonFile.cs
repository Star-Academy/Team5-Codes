using System;
using System.Collections.Generic;
using System.Text.Json;
using Phase4.Models;

namespace Phase4.Database
{
    public class ScoreJsonFile : JsonFile<List<Grade>>
    {
        public ScoreJsonFile(string filePath)
        {
            this.filePath = filePath;
            Init();
        }

<<<<<<< HEAD

        protected override T DeserializeFile<T>(string text)
=======
        protected override List<Grade> DeserializeFile(string text)
>>>>>>> eaec350cad3a6d1c0aed157440235521ca041f68
        {
            var parsedFile = JsonSerializer.Deserialize<List<Grade>>(text);
            foreach (var score in parsedFile)
            {
                Grade.AddScore(score);
            }
            return (T)Convert.ChangeType(parsedFile, typeof(T));
        }
    }
}