using System.Collections.Generic;

namespace SampleLibrary {
    public class InvertedIndex {

        private Dictionary<string, List<string>> wordsInDocs;

        public Dictionary<string, List<string>> WordToDocs { get; set; }

        public InvertedIndex()
        {

        }
        public InvertedIndex (Dictionary<string, List<string>> wordsInDocs) {
            this.wordsInDocs = wordsInDocs;
            Init ();
        }

        private void Init () {
            foreach (var item in wordsInDocs) {
                foreach (var word in item.Value) {
                    WordToDocs = AddWordToDictionary (word, item.Key);
                }
            }
        }

        public Dictionary<string, List<string>> AddWordToDictionary (string word, string doc) {
            if (WordToDocs.ContainsKey(word)) {
                WordToDocs[word].Add(doc);
            } else {
                WordToDocs.Add(word, new List<string>(){"doc"});
            }
            return WordToDocs;
        }
    }
}