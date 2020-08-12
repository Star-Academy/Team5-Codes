using System;
using System.IO;

namespace Phase4.Database
{
    public abstract class JsonFile
    {
        protected string filePath;
        protected object Init() {
            string text = ReadFile(filePath);
            return DeserializeFile<Object>(text);
        }

        protected abstract T DeserializeFile<T>(string text);

        private string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}