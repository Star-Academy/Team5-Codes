using System.Collections.Generic;
using System;
using System.Linq;

namespace SampleLibrary
{
    public class Manager
    {
        public void run()
        {
            string[][] result = Read();
            DocReader docReader = new DocReader();
            Dictionary<string, List<string>> documentWords = docReader.DocumentWords;
            InvertedIndex invertedIndex = new InvertedIndex(documentWords);
            Writer(invertedIndex.GetResult(result).ToList());
        }

        private string[][] Read()
        {
            UserInputReader userInputReader = new UserInputReader();
            return userInputReader.Run();
        }

        private void Writer(HashSet<string> output)
        {
            Writer writer = new Writer();
            bool emptyResult = true;
            foreach(string doc in output){
                writer.Write(doc);
                emptyResult = false;
            }
            if (emptyResult) {
                writer.Write("There is no answer!");
            }
        }
    }
}
