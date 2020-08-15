using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Xunit;

namespace SampleLibrary.Test {
    public class InvertedIndexTest {

        private InvertedIndex invertedIndex;

        ///// This will run before tests /////
        public InvertedIndexTest () {
            Dictionary<string, List<string>> documentWords = new Dictionary<string, List<string>> () {
                {
                "doc_1",
                new List<string> () {
                "word_1",
                "word_2",
                }
                }
            };
            invertedIndex = new InvertedIndex (documentWords);
        }

        [Fact]
        public void AddNewWordToTokenize () {
            Dictionary<string, HashSet<string>> actualValue;
            actualValue = invertedIndex.AddWordToTokenize ("word_3", "doc_1");
            Dictionary<string, HashSet<string>> expectedValue;
            expectedValue = new Dictionary<string, HashSet<string>> () { { "word_3", new HashSet<string> () { "doc_1" } } };
            
            Assert.NotEqual (actualValue, expectedValue);
        }

        [Fact]
        public void AddExistedWordToDictionary () {
            Dictionary<string, HashSet<string>> actualValue = invertedIndex.AddWordToTokenize ("word_1", "doc_1");
            actualValue = invertedIndex.AddWordToTokenize ("word_1", "doc_2");
            Dictionary<string, HashSet<string>> expectedValue = new Dictionary<string, HashSet<string>> () { { "word_1", new HashSet<string> () { "doc_1", "doc_2" } } };
            Assert.Equal (actualValue, expectedValue);
        }
    }
}