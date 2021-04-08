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
            Assert.Equal(1, Fibonacci(1));
        }

        private int Fibonacci(int j)
        {
            if (j==1)
            {
                return 1;
            }

            return 0;
        }
    }
}