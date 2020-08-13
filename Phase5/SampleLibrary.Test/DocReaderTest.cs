using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace SampleLibrary.Test
{
    public class DocReaderTest
    {
        DocReader docReader;
        [TestInitialize]

        private void init()
        {
            docReader = generate(@"..\Docs");
        }
        
        [Fact]
        public void TestDocAddress()
        {
            Xunit.Assert.Equal(docReader.address, @"C:\Users\Farshid726\Desktop\Codes\CodeStar\Team5-Codes\Phase5\Docs\");
        }

        [Fact]
        public void TestNumberOfDocs()
        {
            Xunit.Assert.Equal(, 1);
        }
    }
}
