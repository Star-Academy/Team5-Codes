using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Xunit;

namespace SampleLibrary.Test {
    public class InvertedIndexTest {

        private Dictionary<string, List<string>> wordToDoc;
        private List<string> fisrtWordDocs;
        private InvertedIndex invertedIndex = new InvertedIndex();

        [Fact]
        public void AddNewWordToDictionary () {
            wordToDoc = new Dictionary<string, List<string>> ();
            fisrtWordDocs = new List<string> ();

            Dictionary<string, List<string>> actualValue = invertedIndex.AddWordToDictionary ("word_1", "doc_1");
            Dictionary<string, List<string>> expectedValue = new Dictionary<string, List<string>>() {
                { "word_1", new  List<string>() {"doc_1"} }
            };
            Assert.Equal (actualValue, expectedValue);
        }

        [Fact]
        public void AddExistedWordToDictionary () {
            Dictionary<string, List<string>> actualValue = invertedIndex.AddWordToDictionary ("word_1", "doc_2");
            Dictionary<string, List<string>> expectedValue = new Dictionary<string, List<string>>() {
                { "word_1", new  List<string>() {"doc_1", "doc_2"} }
            };
            Assert.Equal (actualValue, expectedValue);
        }
    }
}