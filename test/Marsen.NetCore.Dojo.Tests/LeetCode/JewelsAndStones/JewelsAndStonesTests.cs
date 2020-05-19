using System;
using Marsen.NetCore.Dojo.LeetCode.JewelsAndStones;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.JewelsAndStones
{
    public class JewelsAndStonesTests
    {
        [Fact]
        public void a_b_ShouldBe_0()
        {
            var jewelsSelector = new JewelsPicker();
            var actual = jewelsSelector.Filter("a", "b");
            Assert.Equal(0,actual);
        }
    }
}