using System;
using System.Collections.Generic;

namespace SampleLibrary
{
    public class UserInputReader
    {

        public string Input { get; set; }

        public UserInputReader()
        {
            Input = Console.ReadLine();
        }

        public string[][] processInput(string s)
        {
            //List<string> positiveSignedWords = takeWords('-');
            //List<string> negativeSignedWords = takeWords('+');
            //List<string> unSignedWords = takeWords(null);
            //return new string[][] { unSignedWords, positiveSignedWords, negativeSignedWords };
            return null;

        }
    }
}
