using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.LeetCode.TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            var lookup = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (lookup.ContainsKey(target - nums[i]))
                {
                    result[0] = lookup[target - nums[i]];
                    result[1] = i;
                    break;
                }

                if (!lookup.ContainsKey(nums[i]))
                {
                    lookup.Add(nums[i], i);
                }
            }

            return result;
        }
    }
}