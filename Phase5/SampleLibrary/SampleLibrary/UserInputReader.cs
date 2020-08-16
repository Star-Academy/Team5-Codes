using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleLibrary
{
    public class UserInputReader
    {

        private readonly char[] inputTokens = { ' ', ',', ';', '(', ')', '\\', '@', '[', ']', '<', '>' };
        private readonly char[] wordTokens = { '+', '-' };
        public List<string> Input { get; set; }
        public string[] PositiveSignedWords { get; set; }
        public string[] NegativeSignedWords { get; set; }
        public string[] UnSignedWords { get; set; }

        public string[][] Run()
        {
            TakeInput();
            return ProcessInput();
        }

        private void TakeInput()
        {
            string text = Console.ReadLine();
            Input = new List<string>(text.Split(inputTokens).Select(p => p.ToLower()).ToList<string>());
        }

        public string[][] ProcessInput(string s = null)
        {
            if (s != null)
            {
                Input = new List<string>(s.Split(inputTokens).Select(p => p.ToLower()).ToList());
            }
            NegativeSignedWords = TakeWords('-').ToArray();
            PositiveSignedWords = TakeWords('+').ToArray();
            UnSignedWords = TakeWords('\0').ToArray();
            return new string[][] { UnSignedWords, PositiveSignedWords, NegativeSignedWords };
        }

        private List<string> TakeWords(char token)
        {
            List<string> ret = new List<string>();
            foreach (string word in Input)
            {
                if (wordTokens.Contains(token) && word.Contains(token))
                    ret.Add(word.Substring(1));
                else if (!wordTokens.Contains(token) && CheckValidation(word))
                    ret.Add(word);
            }
            ret = ret.Where(word => !word.IsNullOrEmpty()).ToList();
            return ret;
        }

        private bool CheckValidation(string word)
        {
            bool isValid = true;
            for (int i = 0; i < wordTokens.Length; i++)
                if (word.Contains(wordTokens[i]))
                    isValid = false;
            return isValid;
        }
    }
}