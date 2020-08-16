using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SampleLibrary
{
    public class DocReader
    {
        public string Root { get; set; }
        public Dictionary<string, List<string>> DocumentWords { get; set; }

        private readonly List<string> files;
        private readonly char[] tokens = { ' ', ',', ';', '(', ')', '\\', '@', '[', ']', '<', '>' };

        public DocReader(String v = null)
        {
            DocumentWords = new Dictionary<string, List<string>>();
            files = new List<string>();
            Root = "..\\Docs" + v;
            listFilesForFolder(Root);
            files.ForEach(doc =>
            {
                DocumentWords.Add(doc, extractWords(doc));
            });
        }

        private List<string> extractWords(string doc)
        {
            string text = File.ReadAllText(doc);
            return new List<string>(text.Split(tokens).Select(p => p.ToLower()).ToList<string>());
        }

        void listFilesForFolder(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (string subDirectory in directories)
            {
                    listFilesForFolder(subDirectory);
            }
            directories = Directory.GetFiles(path);
            foreach (string subFile in directories)
                {
                    files.Add(subFile);
                }
        }
    }
}
