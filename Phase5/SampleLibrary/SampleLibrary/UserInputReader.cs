using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleLibrary
{
    public class UserInputReader
    {

        private readonly char[] tokens = { ' ', ',', ';', '-', '(', ')', '\\', '@', '[', ']', '<', '>' };
        public List<string> Input { get; set; }

        public UserInputReader()
        {
            string text = Console.ReadLine();
            Input = new List<string>(text.Split(tokens).Select(p => p.ToLower()).ToList<string>());
        }

        public string[][] processInput(string s)
        {
            List<string> positiveSignedWords = takeWords('-');
            List<string> negativeSignedWords = takeWords('+');
            List<string> unSignedWords = takeWords('\0');
            return new string[][] { unSignedWords.ToArray(), positiveSignedWords.ToArray(), negativeSignedWords.ToArray() };
        }

        private List<string> takeWords(char token)
        {
            List<string> ret = new List<string>();
            foreach(string word in Input)
            {
                if (word[0] == token)
                    ret.Add(word);
            }
            return ret;
        }
    }
}
