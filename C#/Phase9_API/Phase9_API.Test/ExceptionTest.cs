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
            var imagniaryResponse = new TestResponse(0);
            Assert.Throws<RequestTermination>(() => ResponseValidator.Validate(imagniaryResponse));
        }

        [Fact]
        public void TimeoutExceptionTest()
        {
            var temp = new ResponseValidator();
            var imagniaryResponse = new TestResponse(1);
            Assert.Throws<TimeOutException>(() => ResponseValidator.Validate(imagniaryResponse));
        }

        [Fact]
        public void OriginalExceptionTest()
        {
            var temp = new ResponseValidator();
            var imagniaryResponse = new TestResponse(2);
            Assert.Throws<BuildException>(() => ResponseValidator.Validate(imagniaryResponse));
        }

        [Fact]
        public void ServerExceptionTest()
        {
            var temp = new ResponseValidator();
            var imagniaryResponse = new TestResponse(3);
            Assert.Throws<ServerException>(() => ResponseValidator.Validate(imagniaryResponse));
        }
    }
}