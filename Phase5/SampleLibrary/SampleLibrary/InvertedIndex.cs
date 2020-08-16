using System;
using System.Collections.Generic;

namespace SampleLibrary {
    public class InvertedIndex {

        private readonly Dictionary<string, List<string>> documentWords;

        public Dictionary<string, HashSet<string>> Tokenize { get; private set; }

        public InvertedIndex (Dictionary<string, List<string>> documentWords) {
            this.documentWords = documentWords;
            Tokenize = new Dictionary<string, HashSet<string>> ();
            Init();
        }

        private void Init () {
            foreach (var item in documentWords) {
                foreach (var word in item.Value) {
                    Tokenize = AddWordToTokenize (word, item.Key);
                }
            }
        }

        public Dictionary<string, HashSet<string>> AddWordToTokenize (string word, string doc) {
            if (Tokenize.ContainsKey (word)) {
                Tokenize[word].Add (doc);
            } else {
                Tokenize.Add (word, new HashSet<string> () { doc });
            }
            return Tokenize;
        }

        public HashSet<string> GetDocsContainWord(string word)
        {
            if (Tokenize.ContainsKey(word))
            {
                return Tokenize[word];
            } else {
                return null;
            }
        }

        /*
        line 1 -> noSign
        line 2 -> possetive
        line 3 -> negative
        */
        public HashSet<string> GetResult(string[][] result)
        {
            HashSet<string> output = ProcessNoSignWords(result[0]);
            output.UnionWith(ProcessPossetiveWords(result[1]));
            output.ExceptWith(ProcessPossetiveWords(result[2]));
            return output;
        }

        private HashSet<string> ProcessPossetiveWords(string[] possetiveWords)
        {
            HashSet<string> output =  new HashSet<string>();
            foreach (string word in possetiveWords) {
                if (Tokenize.ContainsKey(word)){
                    HashSet<string> temp = Tokenize[word];
                    output.UnionWith(temp);
                } else {
                    output = new HashSet<string>();
                    break;
                }
            }
            return output;
        }

        private HashSet<string> ProcessNoSignWords(string[] noSignWords)
        {
            HashSet<string> output =  new HashSet<string>(documentWords.Keys);
            foreach (string word in noSignWords) {
                if (Tokenize.ContainsKey(word)){
                    HashSet<string> temp = Tokenize[word];
                    output.IntersectWith(temp);
                } else {
                    output = new HashSet<string>();
                    break;
                }
            }
            return output;
        }
    }
}