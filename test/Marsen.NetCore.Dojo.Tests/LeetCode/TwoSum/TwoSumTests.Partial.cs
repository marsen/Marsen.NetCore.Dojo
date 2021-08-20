using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.TwoSum
{
    public partial class TwoSumTests
    {
        private void GivenTargetIs(int target)
        {
            _target = target;
        }

        private void ShouldBe(params int[] args)
        {
            Assert.Equal(args, _solution.TwoSum(_nums, _target));
        }

        private static void GivenArrayIs(params int[] args)
        {
            _nums = args;
        }
    }
}