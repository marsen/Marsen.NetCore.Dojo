
namespace Marsen.NetCore.Dojo.LeetCode.PickingTicket;

public class Solution
{
    public int MaxTickets(int[] ary)
    {
        var result = 1;
        for (var i = 1; i < ary.Length; i++)
        {
            if (ary[i]-ary[i-1]==0)
            {
                result++;
            }
        }

        return result;
    }
}