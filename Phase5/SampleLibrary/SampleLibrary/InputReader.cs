using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleLibrary
{
    public class InputReader
    {
        private readonly char[] inputTokens = { ' ', ',', ';', '(', ')', '\\', '@', '[', ']', '<', '>' };
       
        public List<string> TakeInput()
        {
            string text = readInput();
            List<string> Input = new List<string>(text.Split(inputTokens).Select(p => p.ToLower()).ToList<string>());
            return Input;
        }

        private string readInput()
        {
            return Console.ReadLine();
        }
    }
}