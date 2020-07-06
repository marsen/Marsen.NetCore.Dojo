using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.LonelyInteger
{
    public class FinderTests
    {
        private readonly Finder _finder = new Finder();

        [Fact]
        public void arr_1_should_be_1()
        {
            Assert.Equal(1,_finder.Get(new[] {1}));
        }
    }

    public class Finder
    {
        public int Get(int[] arr)
        {
            return 1;
        }
    }
}