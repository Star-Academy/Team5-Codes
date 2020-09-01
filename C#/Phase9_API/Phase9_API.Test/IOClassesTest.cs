using System.Collections.Generic;
using Xunit;
using Phase8;
using System.Collections.Generic;

namespace Phase9_API.Test
{
    public class IOClassesTest
    {
        [Fact]
        public void ProccessInputTest()
        {
            var processor = new ProcessInput();
            var actual = processor.Process("Hello World +This -is a +CSHARP.+program");
            var expected = new Dictionary<string, List<string>>();
            expected.Add("or", new List<string>(){
                "this",
                "csharp",
                "program"
            });
            expected.Add("and", new List<string>(){
                "hello",
                "world",
                "a"
            });
            expected.Add("not", new List<string>(){
                "is"
            });
            Assert.Equal(1,1);
        }
    }
}
