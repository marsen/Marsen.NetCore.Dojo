namespace Marsen.NetCore.Dojo.LeetCode.JewelsAndStones
{
    public class JewelsPicker
    {
        public int Filter(string jewels, string stones)
        {
            var result = 0;
            foreach (var j in jewels)
            {
                foreach (var s in stones)
                {
                    if (s.ToString().Contains(j.ToString()))
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}