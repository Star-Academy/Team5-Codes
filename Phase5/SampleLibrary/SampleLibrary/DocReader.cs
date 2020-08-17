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

        public DocReader(String address)
        {
            DocumentWords = new Dictionary<string, List<string>>();
            files = new List<string>();
            Root = address;
            ListFilesForFolder(Root);
            files.ForEach(doc =>
            {
                DocumentWords.Add(doc, ExtractWords(doc));
            });
        }

        private List<string> ExtractWords(string doc)
        {
            string text = File.ReadAllText(doc);
            return new List<string>(text.Split(tokens).Select(p => p.ToLower()).ToList<string>());
        }

        void ListFilesForFolder(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (string subDirectory in directories)
            {
                ListFilesForFolder(subDirectory);
            }
            directories = Directory.GetFiles(path);
            foreach (string subFile in directories)
            {
                files.Add(subFile);
            }
        }
    }
}
