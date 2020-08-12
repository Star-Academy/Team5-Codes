using System.IO;

namespace Phase4.Database
{
    public abstract class JsonFile<T>
    {
        protected string filePath;
        protected void Init() {
            string text = ReadFile(filePath);
            DeserializeFile(text);
        }

        protected abstract T DeserializeFile(string text);

        private string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}