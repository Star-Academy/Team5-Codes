using System.IO;

namespace Phase4.Database
{
    public abstract class JsonFile<T>
    {
        protected string filePath;
        public T Init() {
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