namespace Marsen.NetCore.Dojo.LeetCode.JewelsAndStones
{
    public class JewelsPicker
    {
        public int Filter(string jewels, string stones)
        {
            if (stones.Contains(jewels))
            {
                return 1;
            }

            return 0;
        }
    }
}