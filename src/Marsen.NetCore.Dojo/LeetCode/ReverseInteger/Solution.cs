using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.ReverseInteger;

public class Solution
{
    public int Reverse(int x)
    {
        int symbol = x < 0 ? -1 : 1;
        if (x <= int.MinValue)
        {
            return 0;
        }
        long tmp = long.Parse(new string((symbol * x).ToString().Reverse().ToArray()));
        if (tmp > int.MaxValue || tmp < int.MinValue)
        {
            return 0;
        }

        return symbol * (int)tmp;
    }
}