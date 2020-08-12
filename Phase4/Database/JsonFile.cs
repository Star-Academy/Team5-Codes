using System.Collections.Generic;
using System.IO;

namespace Phase4.Database
{
    public abstract class JsonFile
    {
        protected string filePath;
        protected void Init() {
            string text = ReadFile(filePath);
            DeserializeFile(text);
        }

        protected abstract void DeserializeFile(string text);

        private string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}