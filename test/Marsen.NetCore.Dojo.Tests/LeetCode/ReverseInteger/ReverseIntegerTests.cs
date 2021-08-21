using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.ReverseInteger
{
    public class ReverseIntegerTests
    {
        [Fact]
        public void The_1_Reverse_1()
        {
            var solution = new Solution();
            var actual = solution.Reverse(1);
            Assert.Equal(1, actual);
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