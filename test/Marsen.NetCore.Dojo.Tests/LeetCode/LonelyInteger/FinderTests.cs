using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.LonelyInteger
{
    public class FinderTests
    {
        [Fact]
        public void arr_1_should_be_1()
        {
            var arr = new[] {1};
            var finder = new Finder();
            int result = finder.Get(arr);
            Assert.Equal(1,result);
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