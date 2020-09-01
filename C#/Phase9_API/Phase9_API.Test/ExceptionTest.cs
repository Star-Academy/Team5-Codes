using Phase8;
using Phase8.Exceptions;
using Xunit;

namespace Phase9_API.Test
{
    public class ExceptionTest
    {
        [Fact]
        public void TimeoutExceptionTest()
        {
            var temp = new ResponseValidator();
            var imagniaryResponse = new TestResponse();
            Assert.Throws<RequestTermination>(() => ResponseValidator.Validate(imagniaryResponse));
        }
    }
}