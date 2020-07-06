using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.LonelyInteger
{
    public class FinderTests
    {
        private readonly Finder _finder = new Finder();
        private int[] _array;

        [Fact]
        public void arr_1_should_be_1()
        {
            GivenArrayAs(new[] {1});
            ShouldBe(1);
        }

        [Fact]
        public void arr_2_should_be_2()
        {
            GivenArrayAs(new[] {2});
            ShouldBe(2);
        }


        private void ShouldBe(int expected)
        {
            Assert.Equal(expected, _finder.Get(_array));
        }

        private void GivenArrayAs(int[] array)
        {
            _array = array;
        }
    }

    public class Finder
    {
        public int Get(int[] arr)
        {
            return arr.First();
        }
    }
}