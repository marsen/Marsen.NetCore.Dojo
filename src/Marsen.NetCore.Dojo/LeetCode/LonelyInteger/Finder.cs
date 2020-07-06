using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.LonelyInteger
{
    public class Finder
    {
        public int Get(int[] array)
        {
            return array.GroupBy(x => x).First(x => x.Count() == 1).Key;
        }
    }
}