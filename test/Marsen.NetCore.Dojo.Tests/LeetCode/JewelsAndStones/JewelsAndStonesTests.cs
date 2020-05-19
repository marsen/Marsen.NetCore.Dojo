using System;
using Marsen.NetCore.Dojo.LeetCode.JewelsAndStones;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.JewelsAndStones
{
    public class JewelsAndStonesTests
    {
        private readonly JewelsPicker _jewelsSelector;

        public JewelsAndStonesTests()
        {
            _jewelsSelector = new JewelsPicker();
        }

        [Fact]
        public void a_b_ShouldBe_0()
        {
            ShouldBe("a", "b", 0);
        }
        
        [Fact]
        public void a_a_ShouldBe_1()
        {
            ShouldBe("a", "a", 1);
        }
        
        [Fact]
        public void a_aa_ShouldBe_2()
        {
            ShouldBe("a", "aa", 2);
        }



        
        private void ShouldBe(string jewels, string stones, int expected)
        {
            Assert.Equal(expected, _jewelsSelector.Filter(jewels, stones));
        }
    }
}