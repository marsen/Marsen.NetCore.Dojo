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
            var cases = new Dictionary<int, int>
            {
                {0, 0},
                {1, 1}
            };
            for (int i = 0; i < cases.Count; i++)
            {
                Assert.Equal(cases[i], Fibonacci(i));
            }

            //Assert.Equal(cases[0], Fibonacci(0));
            //Assert.Equal(cases[1], Fibonacci(1));
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