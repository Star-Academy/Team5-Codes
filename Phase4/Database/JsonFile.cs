using System.IO;

namespace Phase4.Database
{
    public abstract class JsonFile
    {
        protected string filePath;
        protected void Init() {
            string text = ReadFile(filePath);
            deserializeFile(text);
        }

        protected abstract void deserializeFile(string text);

        private string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}