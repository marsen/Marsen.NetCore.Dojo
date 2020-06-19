using Marsen.NetCore.Dojo.LeetCode.JewelsAndStones;
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

        [Fact]
        public void aB_aBa_ShouldBe_3()
        {
            ShouldBe("aB", "aBa", 3);
        }

        [Fact]
        public void abc_cat_ShouldBe_2()
        {
            ShouldBe("abc", "cat", 2);
        }

        [Fact]
        public void abc_apple_ShouldBe_1()
        {
            ShouldBe("abc", "apple", 1);
        }

        private void ShouldBe(string jewels, string stones, int expected)
        {
            Assert.Equal(expected, _jewelsSelector.Filter(jewels, stones));
        }
    }
}