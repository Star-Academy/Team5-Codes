using System;
using Phase8.Exceptions;
using Xunit;
using Phase8;

namespace Phase9_API.Test {
    public class ExceptionTest {
        [Fact]
        public void TimeoutExceptionTest () {

            Assert.Throws<NullReferenceException> (() =>
                ResponseValidator.Validate ((Nest.ResponseBase) response));
        }
    }
}