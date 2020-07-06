using Marsen.NetCore.Dojo.LeetCode.FindTheMedian;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.FindTheMedian
{
    public class FindTheMedianTests
    {
        private readonly ArrayFinder _target = new ArrayFinder();

        private int[] _array;

        private void GiveArrayAs(params int[] array)
        {
            _array = array;
        }

        private void ShouldBe(int median)
        {
            Assert.Equal(median, _target.Median(_array));
        }

        [Fact]
        public void arr_1_should_be_1()
        {
            GiveArrayAs(1);
            ShouldBe(1);
        }

        [Fact]
        public void arr_2_should_be_2()
        {
            GiveArrayAs(2);
            ShouldBe(2);
        }

        [Fact]
        public void arr_1_2_3_should_be_2()
        {
            GiveArrayAs(1, 2, 3);
            ShouldBe(2);
        }

        [Fact]
        public void arr_2_3_1_should_be_2()
        {
            GiveArrayAs(2, 3, 1);
            ShouldBe(2);
        }

        [Fact]
        public void arr_0_1_2_4_6_5_3_should_be_3()
        {
            GiveArrayAs(0, 1, 2, 4, 6, 5, 3);
            ShouldBe(3);
        }
    }
}