using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.JewelsAndStones;

public class JewelsPicker
{
    public int Filter(string jewels, string stones)
    {
        return stones.Count(jewels.Contains);
    }
}