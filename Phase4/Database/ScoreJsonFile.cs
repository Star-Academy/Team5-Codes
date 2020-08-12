using System;
using System.Collections.Generic;
using System.Text.Json;
using Phase4.Models;

namespace Phase4.Database
{
    public class ScoreJsonFile : JsonFile
    {
        public ScoreJsonFile(string filePath)
        {
            this.filePath = filePath;
            Init();
        }


        protected override T DeserializeFile<T>(string text)
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