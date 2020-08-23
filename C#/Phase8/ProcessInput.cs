
using System;
using System.Collections.Generic;

namespace Phase8
{
    public class ProcessInput
    {
        private readonly char[] splitChar = { ' ', ',', '.', ';', '(', ')', '\\', '@', '[', ']', '<', '>' };

        /// <summary>
        /// Process user input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns a dictionary: Key -> "or", "and", "not". 
        /// Value -> tokens</returns>
        public Dictionary<string, List<string>> Process(string input)
        {
            var NoSignWords = new List<string>();
            var positiveWords = new List<string>();
            var negativeWords = new List<string>();

            var splitInput = input.Split(splitChar);
            foreach (var item in splitInput)
            {
                switch (item[0])
                {
                    case '+':
                        positiveWords.Add(item);
                        break;
                    case '-':
                        negativeWords.Add(item);
                        break;
                    default:
                        NoSignWords.Add(item);
                        break;
                }
            }

            return new Dictionary<string, List<string>>(){
                {"or", positiveWords},
                {"not", negativeWords},
                {"and", NoSignWords}
            };
        }
    }
}