using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            var lookup = new Dictionary<int, int>();
            int i = 0;
            foreach (var n in nums)
            {
                if (lookup.ContainsKey(target - n))
                {
                    result[0] = lookup[target - n];
                    result[1] = i;
                    return result;
                }

                if (!lookup.ContainsKey(nums[i]))
                {
                    lookup.Add(nums[i], i);
                }

                i++;

            }

            return result;
        }
    }
}