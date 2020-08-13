using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace SampleLibrary.Test
{
    public class DocReaderTest
    {
        private DocReader reader;
        [TestInitialize]
        private void init()
        {
            reader = DocReader.generate("Docs");
        }

        [Fact]
        public void test1() => Xunit.Assert.Equal(reader.DocumentWords.Count, 1000);

        [Fact]
        public void test2() => Xunit.Assert.Equal(reader.root, @"C:\Users\Farshid726\Desktop\Codes\CodeStar\Team5-Codes\Phase5\Docs");
        
        [Fact]
        public void test3() => Xunit.Assert.Equal(reader.DocumentWords["58044"].Contains("announcing"), true);

        [Fact]
        public void test4() => Xunit.Assert.Equal(reader.DocumentWords["58044"].Contains("presidentia"), true);

        [Fact]
        public void test5() => Xunit.Assert.Equal(reader.DocumentWords["58057"].Contains("when"), true);

        [Fact]
        public void test6()
        {
            Xunit.Assert.Equal(reader.DocumentWords["58057"].Contains("ishalla"), false);
        }

    }
}
