using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class FibonacciTests
    {
        private readonly Dictionary<int, int> _cases = new()
        {
            { 0, 0 },
            { 1, 1 },
            { 2, 1 },
            { 3, 2 }
        };

        [Fact]
        public void TestFibonacci()
        {
            for (var i = 0; i < _cases.Count; i++) Assert.Equal(_cases[i], Fibonacci(i));
        }

        private int Fibonacci(int input)
        {
            return input switch
            {
                0 => 0,
                1 => 1,
                _ => Fibonacci(input - 2) + Fibonacci(input - 1)
            };
        }
    }
}