using System;
using System.Collections.Generic;
using System.IO;
using Phase4.Models;

namespace Phase4.Database
{
    public abstract class JsonFile<T>
    {
        protected string filePath;
        protected object Init() {
            string text = ReadFile(filePath);
            return DeserializeFile(text);
        }

        protected abstract T DeserializeFile(string text);

        private string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}