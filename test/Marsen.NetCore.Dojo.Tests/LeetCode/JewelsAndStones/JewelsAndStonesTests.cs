using System;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.JewelsAndStones
{
    public class JewelsAndStonesTests
    {
        [Fact]
        public void a_b_ShouldBe_0()
        {
            var jewelsSelector = new JewelsAndStones();
            var actual = jewelsSelector.Filter("a", "b");
            Assert.Equal(0,actual);
        }
    }

    public class JewelsAndStones
    {
        public int Filter(string jewels, string stones)
        {
            return 0;
        }
    }
}