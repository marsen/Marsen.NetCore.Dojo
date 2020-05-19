using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.JewelsAndStones
{
    public class JewelsPicker
    {
        public int Filter(string jewels, string stones)
        {
            return stones.Count(s=>jewels.Contains(s));
            // return jewels.Sum(j => stones.Count(s => s == j));
        }
    }
}