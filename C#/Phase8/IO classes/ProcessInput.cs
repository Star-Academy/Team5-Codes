using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Phase8
{
    public class ProcessInput
    {
        private readonly char[] splitChar = { ' ', ',', '.', ';', '(', ')', '\\', '@', '[', ']', '<', '>' };
        private readonly Regex noSignRegex = new Regex(@"^\w+");
        private readonly Regex positiveRegex = new Regex(@"^\+\w+");
        private readonly Regex negativeRegex = new Regex(@"^\-\w+");

        /// <summary>
        /// Process user input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns a dictionary: Key -> "or", "and", "not". 
        /// Value -> tokens</returns>
        public Dictionary<string, List<string>> Process(string input)
        {
            var splitInput = input.Split(splitChar);
            var splitInputList = new List<string>(splitInput);

            var NoSignWords = splitInputList.FindAll(e => noSignRegex.IsMatch(e));
            var positiveWords = splitInputList.FindAll(e => positiveRegex.IsMatch(e));
            var negativeWords = splitInputList.FindAll(e => negativeRegex.IsMatch(e));

            return new Dictionary<string, List<string>>() { { "or", positiveWords }, { "not", negativeWords }, { "and", NoSignWords }
            };
        }
    }
}