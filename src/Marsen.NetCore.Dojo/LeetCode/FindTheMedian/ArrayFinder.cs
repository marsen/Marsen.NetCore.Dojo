using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.FindTheMedian
{
    public class ArrayFinder
    {
        public int Median(int[] array)
        {
            return array.OrderBy(x => x)
                .ElementAt(array.Length / 2);
        }
    }
}