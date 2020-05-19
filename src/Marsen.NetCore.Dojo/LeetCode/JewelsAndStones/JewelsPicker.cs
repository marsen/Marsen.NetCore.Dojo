namespace Marsen.NetCore.Dojo.LeetCode.JewelsAndStones
{
    public class JewelsPicker
    {
        public int Filter(string jewels, string stones)
        {
            var result = 0;
            if (stones.Contains(jewels))
            {
                result++;
            }

            return result;
        }
    }
}