using Xunit;

namespace SampleLibrary.Test
{
    public class DocReaderTest
    {
        private DocReader reader = new DocReader(@"..\..\..\..\..\..\Phase5\SampleLibrary\Docs");

        [Fact]
        public void CountTheWords() => Xunit.Assert.Equal(reader.DocumentWords.Count, 1000);

        [Fact]
        public void ContainTest1() => Xunit.Assert.Equal(reader.DocumentWords[reader.Root + "\\EnglishData\\58044"].Contains("announcing"), true);

        [Fact]
        public void ContainTest2() => Xunit.Assert.Equal(reader.DocumentWords[reader.Root + "\\EnglishData\\58044"].Contains("presidentia"), true);

        [Fact]
        public void ContainTest3() => Xunit.Assert.Equal(reader.DocumentWords[reader.Root + "\\EnglishData\\58057"].Contains("when"), true);

        [Fact]
        public void NotContainTest1() => Xunit.Assert.Equal(reader.DocumentWords[reader.Root + "\\EnglishData\\58057"].Contains("ishalla"), false);

        [Fact]
        public void NotContainTest2() => Xunit.Assert.Equal(reader.DocumentWords[reader.Root + "\\EnglishData\\58061"].Contains("a "), false);
    }
}
