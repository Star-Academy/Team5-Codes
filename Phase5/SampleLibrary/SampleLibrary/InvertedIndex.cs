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
            if (Data.ContainsKey(word))
            {
                Data[word].Add(doc);
            }
            else
            {
                Data.Add(word, new HashSet<string>() { doc });
            }
            return Data;
        }

        public HashSet<string> GetDocsContainWord(string word)
        {
            if (Data.ContainsKey(word))
            {
                return Data[word];
            }
            else
            {
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
            HashSet<string> output = new HashSet<string>();
            foreach (string word in possetiveWords)
            {
                if (Data.ContainsKey(word))
                {
                    HashSet<string> temp = Data[word];
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
            HashSet<string> output = new HashSet<string>(documentWords.Keys);
            foreach (string word in noSignWords)
            {
                if (Data.ContainsKey(word))
                {
                    HashSet<string> temp = Data[word];
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