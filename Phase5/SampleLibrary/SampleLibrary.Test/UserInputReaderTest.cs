using Moq;
using Xunit;

namespace SampleLibrary.Test
{
    public class UserInputReaderTest
    {
        [Fact]
        public void test1()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test1 => test1.ProcessInput("salam +ishalla -hala")).Returns(new string[][]{ new string[] { "salam" },
                new string[] { "ishalla" },
                new string[] { "hala" } });
        }

        [Fact]
        public void test2()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test2 => test2.ProcessInput("hi")).Returns(new string[][] { new string[] { "hi" }, new string[] { }, new string[] { } });
        }

        [Fact]
        public void test3()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test2 => test2.ProcessInput("+hi")).Returns(new string[][] { new string[] { }, new string[] { "hi" }, new string[] { } });
        }

        [Fact]
        public void test4()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test2 => test2.ProcessInput("-hi")).Returns(new string[][] { new string[] { }, new string[] { }, new string[] { "hi" } });
        }

        [Fact]
        public void test5()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test1 => test1.ProcessInput("salam -ishalla +hala")).Returns(new string[][]{ new string[] { "salam" },
                new string[] { "ishalla" },
                new string[] { "hala" } });
        }

        [Fact]
        public void test6()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test1 => test1.ProcessInput("salam -hala")).Returns(new string[][]{ new string[] { "salam" },
                new string[] {  },
                new string[] { "hala" } });
        }

        [Fact]
        public void test7()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test1 => test1.ProcessInput("")).Returns(new string[][]{ new string[] {  },
                new string[] {  },
                new string[] { } });
        }

        [Fact]
        public void test8()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test1 => test1.ProcessInput("salam +salam -salam")).Returns(new string[][]{ new string[] { "salam" },
                new string[] { "salam" },
                new string[] { "salam" } });
        }

        [Fact]
        public void test9()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test1 => test1.ProcessInput("-ishalla -hala")).Returns(new string[][]{ new string[] { },
                new string[] { },
                new string[] { "ishalla", "hala" } });
        }


        [Fact]
        public void test10()
        {
            var mock = new Mock<UserInputReader>();
            mock.Setup(test1 => test1.ProcessInput("salam salam salam")).Returns(new string[][]{ new string[] { "salam" },
                new string[] { },
                new string[] { } });
        }
    }
}
