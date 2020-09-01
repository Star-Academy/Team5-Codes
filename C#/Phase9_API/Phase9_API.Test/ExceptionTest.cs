using System.Threading;
using System;
using Phase8.Exceptions;
using Xunit;
using Phase8;
using System.Collections.Generic;

namespace Phase9_API.Test {
    public class ExceptionTest {
        [Fact]
        public void TimeoutExceptionTest () {
            List<int> a = null;
            Assert.Throws<NullReferenceException> (() =>
                a.Add(2));
        }
    }
}