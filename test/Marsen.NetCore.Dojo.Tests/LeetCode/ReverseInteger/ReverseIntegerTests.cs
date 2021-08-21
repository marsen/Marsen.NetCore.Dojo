using System;
using System.Linq;
using System.Runtime.InteropServices;
using Marsen.NetCore.Dojo.Kata.ReverseString;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.ReverseInteger
{
    public class ReverseIntegerTests
    {
        private readonly Solution _solution = new();

        [Fact]
        public void The_1_Reverse_1()
        {
            var actual = _solution.Reverse(1);
            Assert.Equal(1, actual);
        }

        [Fact]
        public void The_12_Reverse_21()
        {
            var actual = _solution.Reverse(12);
            Assert.Equal(21, actual);
        }

        [Fact]
        public void The_Negative_12_Reverse_Negative_21()
        {
            var actual = _solution.Reverse(-12);
            Assert.Equal(-21, actual);
        }

        [Fact]
        public void The_1534236469_Reverse_9646324351()
        {
            var actual = _solution.Reverse(1534236469);
            Assert.Equal(9646324351, actual);
        }
    }

    public class Solution
    {
        public long Reverse(long x)
        {
            long symbol = x < 0 ? -1 : 1;
            var result = new string((symbol * x).ToString().Reverse().ToArray());
            return symbol * long.Parse(result);
            
        }
    }
}