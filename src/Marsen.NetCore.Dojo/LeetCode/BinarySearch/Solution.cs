using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        if (nums.Length > 0)
            return 0;
        return -1;
    }

    /// <summary>
    /// Runtime: 124 ms
    /// Memory Usage: 51.1 MB
    /// </summary>
    private static int FastestSearch(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var center = (right - left) / 2 + left;
            if (nums[center] == target)
            {
                return center;
            }

            if (nums[center] < target)
            {
                left = center + 1;
            }
            else
            {
                right = center - 1;
            }
        }

        return -1;
    }

    /// <summary>
    /// Runtime: 236 ms
    /// Memory Usage: 41.4 MB
    /// </summary>
    private int SpanSearch(int[] nums, int target)
    {
        Span<int> searchSpan = nums;
        int indexOffset = 0;
        while (!searchSpan.IsEmpty)
        {
            var middleIndex = searchSpan.Length / 2;
            int middleValue = searchSpan[middleIndex];
            if (middleValue == target)
                return middleIndex + indexOffset;
            if (middleValue > target)
            {
                searchSpan = searchSpan[..middleIndex];
                continue;
            }

            indexOffset += middleIndex + 1;
            searchSpan = searchSpan[(middleIndex + 1)..];
        }

        return -1;
    }

    /// <summary>
    /// Runtime: 153 ms
    /// Memory Usage: 42 MB
    /// </summary>
    private int EasyToUnderstand(int[] nums, int target)
    {
        return nums.ToList().IndexOf(target);
    }
}