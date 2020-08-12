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
        }

        protected override List<Grade> DeserializeFile(string text)
        {
            var parsedFile = JsonSerializer.Deserialize<List<Grade>>(text);
            return parsedFile;
        }
    }
}