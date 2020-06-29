using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.FindTheMedian
{
    public class ArrayFinder
    {
        public int Median(int[] array)
        {
            var list = array.ToList().OrderBy(x => x).ToList();
            return list.ElementAt(list.Count / 2);
        }
    }
}