using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.PickingTicket;

public class Solution
{
    public int MaxTickets(int[] ary)
    {
        var ary2 = ary.OrderBy(x => x).ToArray();
        var current = 1;
        var result = 1;

        for (var i = 1; i < ary2.Length; i++)
        {
            if (ary2[i] - ary2[i - 1] <= 1)
            {
                current++;
            }
            else
            {
                result = current;
                current = 1;
            }
        }

        if (current > result)
        {
            result = current;
        }

        return result;
    }
}