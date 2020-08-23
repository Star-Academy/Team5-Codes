
using System.Collections.Generic;

namespace Phase8
{
    public class ProcessInput
    {
        private readonly char[] splitChar = { ' ', ',', '.', ';', '(', ')', '\\', '@', '[', ']', '<', '>' };

        // public List<string> NoSignWords { get; set; }
        // public List<string> PositvieWords { get; set; }
        // public List<string> NegativeWords { get; set; }

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
                switch (item)
                {
                    case "+":
                        positiveWords.Add(item);
                        break;
                    case "-":
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