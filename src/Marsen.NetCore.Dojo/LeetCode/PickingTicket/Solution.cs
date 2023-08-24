
namespace Marsen.NetCore.Dojo.LeetCode.PickingTicket;

public class Solution
{
    public int MaxTickets(int[] ary)
    {
        int result = 1;
        for (int i = 1; i < ary.Length; i++)
        {
            if (ary[i]-ary[i-1]==0)
            {
                result++;
            }
        }

        return result;
        return ary.Length;
    }
}