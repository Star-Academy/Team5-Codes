using System;
using System.Collections.Generic;
using System.IO;

namespace SampleLibrary
{
    public class DocReader
    {
        private static DocReader docReader = null;
        public string root { get; set; }
        public Dictionary<string, List<string>> DocumentWords { get; set; }
        public static DocReader generate(string v)
        {
            if (docReader == null)
                docReader = new DocReader(v);
            return docReader;
        }

        private DocReader()
        {
        }

        private DocReader(String v)
        {
            root = Path.GetFullPath(v);
        }
    }
}
