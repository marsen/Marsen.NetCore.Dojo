using System;
using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TDDbyExsample
{
    public class FibonacciTests
    {
        [Fact]
        public void TestFibonacci()
        {
            var testData = new Dictionary<int, int>()
            {
                {0, 0},
                {1, 1}
            };
            Assert.Equal(0, Fibonacci(0));
            Assert.Equal(1, Fibonacci(1));
        }

        private int Fibonacci(int input)
        {
            if (input == 1)
            {
                return 1;
            }

            return 0;
        }
    }
}