using System.Collections.Generic;

namespace SampleLibrary
{
    public class InvertedIndex
    {

        private readonly Dictionary<string, List<string>> documentWords;

        public Dictionary<string, HashSet<string>> Data { get; private set; }

        public InvertedIndex(Dictionary<string, List<string>> documentWords)
        {
            this.documentWords = documentWords;
            Data = new Dictionary<string, HashSet<string>>();
            Init();
        }

        private void Init()
        {
            foreach (var item in documentWords)
            {
                foreach (var word in item.Value)
                {
                    Data = AddWordToTokenize(word, item.Key);
                }
            }
        }

        public Dictionary<string, HashSet<string>> AddWordToTokenize(string word, string doc)
        {
            if (!Data.ContainsKey(word))
                Data[word] = new HashSet<string>();
            Data[word].Add(doc);
            return Data;
        }

        public HashSet<string> GetDocsContainWord(string word)
        {
            if (Data.TryGetValue(word, out var docs)) {
                return docs;
            }
            return null;
        }

        public HashSet<string> GetResult(string[] noSing, string[] positive, string[] negative)
        {
            var output = ProcessNoSignWords(noSing);
            output.UnionWith(ProcessPositiveWords(positive));
            output.ExceptWith(ProcessPositiveWords(negative));
            return output;
        }

        private HashSet<string> ProcessPositiveWords(string[] possetiveWords)
        {
            var output = new HashSet<string>();
            foreach (var word in possetiveWords)
            {
                var temp = new HashSet<string>();
                if (Data.TryGetValue(word, out temp))
                {
                    output.UnionWith(temp);
                }
                else
                {
                    output = new HashSet<string>();
                    break;
                }
            }
            return output;
        }

        private HashSet<string> ProcessNoSignWords(string[] noSignWords)
        {
            var output = new HashSet<string>(documentWords.Keys);
            foreach (var word in noSignWords)
            {
                var temp = new HashSet<string>();
                if (Data.TryGetValue(word, out temp))
                {
                    output.IntersectWith(temp);
                }
                else
                {
                    output = new HashSet<string>();
                    break;
                }
            }
            return output;
        }
    }
}