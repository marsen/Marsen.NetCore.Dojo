using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.PickingTicket;

public class Solution
{
    public int MaxTickets(int[] ary)
    {
        var tickets = SortArray(ary);
        var current = 1;
        var result = 1;

        for (var i = 1; i < tickets.Length; i++)
        {
            if (tickets[i] - tickets[i - 1] <= 1)
            {
                current++;
            }
            else
            {
                result = current;
                current = 1;
            }
        }
        return Math.Max(current,result);
    }

    private static int[] SortArray(int[] ary)
    {
        return ary.OrderBy(x => x).ToArray();
    }
}