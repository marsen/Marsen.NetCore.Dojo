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
        public void The_1534236469_Reverse_0()
        {
            var actual = _solution.Reverse(1534236469);
            Assert.Equal(0, actual);
        }

        [Fact]
        public void The_120_Reverse_21()
        {
            var actual = _solution.Reverse(120);
            Assert.Equal(21, actual);
        }

        [Fact]
        public void The_Negative_2147483648_Reverse_0()
        {
            var actual = _solution.Reverse(-2147483648);
            Assert.Equal(0, actual);
        }
    }

    public class Solution
    {
        public int Reverse(int x)
        {
            int symbol = x < 0 ? -1 : 1;
            if (x <= int.MinValue)
            {
                return 0;
            }
            long tmp = long.Parse(new string((symbol * x).ToString().Reverse().ToArray()));
            if (tmp > int.MaxValue || tmp < int.MinValue)
            {
                return 0;
            }

            return symbol * (int)tmp;
        }
    }
}