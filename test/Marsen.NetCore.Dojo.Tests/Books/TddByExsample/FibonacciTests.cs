using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TDDbyExsample
{
    public class FibonacciTests
    {
        [Fact]
        public void TestFibonacci()
        {
            Assert.Equal(0, Fibonacci(0));
        }

        private int Fibonacci(int j)
        {
            throw new NotImplementedException();
        }
    }
}