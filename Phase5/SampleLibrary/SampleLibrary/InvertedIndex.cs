using System.Collections.Generic;

namespace SampleLibrary {
    public class InvertedIndex {

        private Dictionary<string, List<string>> documentWords;
        private Dictionary<string, HashSet<string>> tokenize;

        public Dictionary<string, HashSet<string>> Tokenize {
            get {
                return this.tokenize;
            }
        }

        public InvertedIndex (Dictionary<string, List<string>> documentWords) {
            this.documentWords = documentWords;
            tokenize = new Dictionary<string, HashSet<string>> ();
            Init();
        }

        private void Init () {
            foreach (var item in documentWords) {
                foreach (var word in item.Value) {
                    tokenize = AddWordToTokenize (word, item.Key);
                }
            }
        }

        public Dictionary<string, HashSet<string>> AddWordToTokenize (string word, string doc) {
            if (tokenize.ContainsKey (word)) {
                tokenize[word].Add (doc);
            } else {
                tokenize.Add (word, new HashSet<string> () { doc });
            }
            return tokenize;
        }
    }
}