using Phase8;
using Phase8.Exceptions;
using Xunit;

namespace Phase9_API.Test
{
    public class ExceptionTest
    {
        [Fact]
        public void TerminateEarlyExceptionTest()
        {
            var temp = new ResponseValidator();
            var imaginaryResponse = new TestResponse(0);
            Assert.Throws<RequestTermination>(() => ResponseValidator.Validate(imaginaryResponse));
        }

        [Fact]
        public void TimeoutExceptionTest()
        {
            var temp = new ResponseValidator();
            var imaginaryResponse = new TestResponse(1);
            Assert.Throws<TimeOutException>(() => ResponseValidator.Validate(imaginaryResponse));
        }

        [Fact]
        public void OriginalExceptionTest()
        {
            var temp = new ResponseValidator();
            var imaginaryResponse = new TestResponse(2);
            Assert.Throws<BuildException>(() => ResponseValidator.Validate(imaginaryResponse));
        }

        [Fact]
        public void ServerExceptionTest()
        {
            var temp = new ResponseValidator();
            var imaginaryResponse = new TestResponse(3);
            Assert.Throws<ServerException>(() => ResponseValidator.Validate(imaginaryResponse));
        }
    }
}