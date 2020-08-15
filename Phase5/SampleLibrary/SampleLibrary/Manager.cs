﻿using System.Collections.Generic;
using System;

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
            Writer(invertedIndex.GetResult(result));
        }

        private string[][] Read()
        {
            UserInputReader userInputReader = new UserInputReader();
            return userInputReader.ProcessInput();
        }

        private void Writer(HashSet<string> output)
        {
            Writer writer = new Writer();
            foreach(string doc in output){
                writer.Write(doc);
            }
        }
    }
}
