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
            DocReader = new DocReader(@"../../../../../../Phase5/SampleLibrary/Docs");
            InvertedIndex = new InvertedIndex(DocReader.DocumentWords);
        }
        public void Run()
        {
            string[][] result = Read();
            Writer.Write(InvertedIndex.GetResult(result[0], result[1], result[2]));
        }

        private string[][] Read()
        {
            InputProcessor inputProcessor = new InputProcessor();
            return inputProcessor.Run();
        }
    }
}
