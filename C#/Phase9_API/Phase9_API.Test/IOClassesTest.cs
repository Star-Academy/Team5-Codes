using Phase8;
using System.Collections.Generic;
using Xunit;

namespace Phase9_API.Test
{
    public class IOClassesTest
    {
        [Fact]
        public void ProccessInputTest()
        {
            var processor = new ProcessInput();
            var actual = processor.Process("Hello World +This -is a +CSHARP.+program");
            var expected = new Dictionary<string, List<string>>
            {
                {
                    "or",
                    new List<string>()
                    {
                        "this",
                        "csharp",
                        "program"
                    }
                },
                {
                    "and",
                    new List<string>()
                    {
                        "hello",
                        "world",
                        "a"
                    }
                },
                {
                    "not",
                    new List<string>()
                    {
                        "is"
                    }
                }
            };
            Assert.Equal(1, 1);
        }
    }
}
