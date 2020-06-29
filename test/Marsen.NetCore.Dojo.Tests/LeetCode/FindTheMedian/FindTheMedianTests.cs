using System.Linq;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.FindTheMedian
{
    public class FindTheMedianTests
    {
        private readonly ArrayFinder _target = new ArrayFinder();

        private int[] _array;

        private void GiveTheArrayIs(int[] array)
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
            GiveTheArrayIs(new[] {1});
            ShouldBe(1);
        }

        [Fact]
        public void arr_2_should_be_2()
        {
            GiveTheArrayIs(new[] {2});
            ShouldBe(2);
        }

        [Fact]
        public void arr_1_2_3_should_be_2()
        {
            GiveTheArrayIs(new[] {1, 2, 3});
            ShouldBe(2);
        }
    }

    public class ArrayFinder
    {
        public int Median(int[] array)
        {
            var list = array.ToList();
            return list.ElementAt(list.Count / 2);
        }
    }
}