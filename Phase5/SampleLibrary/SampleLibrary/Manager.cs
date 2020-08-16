using System.Collections.Generic;
using System.Linq;

namespace SampleLibrary
{
    public class Manager
    {
        Writer Writer { get; set; }
        DocReader DocReader { get; set; }

        InvertedIndex InvertedIndex { get; set; }

        public Manager()
        {
            Writer = new Writer();
            DocReader = new DocReader();
            InvertedIndex = new InvertedIndex(DocReader.DocumentWords);
        }
        public void run()
        {
            string[][] result = Read();
            Writer.Write(InvertedIndex.GetResult(result));
        }

        private string[][] Read()
        {
            UserInputReader userInputReader = new UserInputReader();
            return userInputReader.Run();
        }
    }
}
