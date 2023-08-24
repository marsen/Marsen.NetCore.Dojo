using System;

namespace Marsen.NetCore.Dojo.LeetCode.PickingTicket;

public class Solution
{
    public int MaxTickets(int[] ary)
    {
        Array.Sort(ary);
        int current = 1, result = 1;

        for (var i = 1; i < ary.Length; i++)
        {
            if (ary[i] - ary[i - 1] > 1)
            {
                result = current;
                current = 1;
            }
            else
                current++;
        }

        return Math.Max(current, result);
    }
}
