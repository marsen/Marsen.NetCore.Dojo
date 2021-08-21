using System;
using System.Runtime.InteropServices;
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
    }

    public class Solution
    {
        public int Reverse(int x)
        {
            return 1;
        }
    }
}