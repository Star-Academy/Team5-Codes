using System.Collections.Generic;
using Xunit;

namespace SampleLibrary.Test
{
    public class InvertedIndexTest
    {

        private InvertedIndex invertedIndex;

        ///// This will run before tests /////
        public InvertedIndexTest()
        {
            Dictionary<string, List<string>> documentWords = new Dictionary<string, List<string>>() {
                {
                    "doc_1",
                    new List<string> () {
                    "word_1",
                    "word_2",
                    }
                },
                {
                    "doc_2",
                    new List<string> () {
                        "word_1"
                    }
                }
            };
            invertedIndex = new InvertedIndex(documentWords);
        }

        [Fact]
        public void AddNewWordToTokenize()
        {
            Dictionary<string, HashSet<string>> actualValue;
            actualValue = invertedIndex.AddWordToTokenize("word_3", "doc_1");
            Dictionary<string, HashSet<string>> expectedValue;
            expectedValue = new Dictionary<string, HashSet<string>>() {
                 { "word_3", new HashSet<string> () { "doc_1" } },
                 { "word_1", new HashSet<string> () { "doc_1", "doc_2"} },
                 { "word_2", new HashSet<string> () { "doc_1"} }
            };

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void AddExistedWordToDictionary()
        {
            Dictionary<string, HashSet<string>> actualValue;
            actualValue = invertedIndex.AddWordToTokenize("word_1", "doc_3");
            Dictionary<string, HashSet<string>> expectedValue;
            expectedValue = new Dictionary<string, HashSet<string>>() {
                 { "word_1", new HashSet<string> () { "doc_1", "doc_2", "doc_3"} },
                 { "word_2", new HashSet<string> () { "doc_1"} }
            };
            Assert.Equal(expectedValue, actualValue);
        }
    }
}