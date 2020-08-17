using Xunit;

namespace SampleLibrary.Test
{
    public class InputProcessorTest
    {
        private InputProcessor inputReader = new InputProcessor();
        [Fact]
        public void Test1()
        {
            Assert.Equal(new string[][]{ new string[] { "salam" },
                new string[] { "ishalla" },
                new string[] { "hala" } }, inputReader.ProcessInput("salam +ishalla -hala"));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(new string[][]{ new string[] { "hi" },
                new string[] {  },
                new string[] {  } }, inputReader.ProcessInput("HI"));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(new string[][]{ new string[] {  },
                new string[] { "hi" },
                new string[] {  } }, inputReader.ProcessInput("+hI"));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(new string[][]{ new string[] {  },
                new string[] {  },
                new string[] { "hi" } }, inputReader.ProcessInput("-hI"));
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(new string[][]{ new string[] { "salam" },
                new string[] { "ishalla" },
                new string[] { "hala" } }, inputReader.ProcessInput("salam +ishalla -hala"));
        }

        [Fact]
        public void Test6()
        {
            Assert.Equal(new string[][]{ new string[] { "salam" },
                new string[] { },
                new string[] { "hala" } }, inputReader.ProcessInput("salam -hala"));
        }

        [Fact]
        public void Test7()
        {
            Assert.Equal(new string[][]{ new string[] { },
                new string[] {  },
                new string[] {  } }, inputReader.ProcessInput(""));
        }

        [Fact]
        public void Test8()
        {
            Assert.Equal(new string[][]{ new string[] { "salam" },
                new string[] { "salam" },
                new string[] { "salam" } }, inputReader.ProcessInput("salam -salam +salam"));
        }

        [Fact]
        public void Test9()
        {
            Assert.Equal(new string[][]{ new string[] { },
                new string[] { },
                new string[] { "ishalla", "hala" } }, inputReader.ProcessInput("-ishalla -hala"));
        }


        [Fact]
        public void Test10()
        {
            Assert.Equal(new string[][]{ new string[] { "salam", "salam", "salam" },
                new string[] { },
                new string[] { } }, inputReader.ProcessInput("salam SALAm SaLaM"));
        }
    }
}
