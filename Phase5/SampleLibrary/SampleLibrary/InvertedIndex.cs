﻿using System;
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

        public HashSet<string> GetDocsContainWord(string word)
        {
            if (tokenize.ContainsKey(word))
            {
                return tokenize[word];
            } else {
                return null;
            }
        }

        /*
        line 1 -> negative
        line 2 -> possetive
        line 3 -> noSign
        */
        public HashSet<string> GetResult(string[][] result)
        {
            HashSet<string> output = ProcessNoSignWords(result[2]);
            
            return null;
        }

        private HashSet<string> ProcessNoSignWords(string[] noSignWords)
        {
            HashSet<string> output =  new HashSet<string>();
            if (noSignWords.Length == 1) {
                output = tokenize[noSignWords[0]];
            } else {
                for
            }
            foreach(string word in noSignWords){

            }


            return output;
        }
    }
}