using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.Shape
{
    public class ShapeValidator
    {
        public bool IsTriangle(int edge1, int edge2, int edge3)
        {
            var edges = new List<int> {edge1, edge2, edge3};
            var max = edges.Max();
            var sumOfOther2Edges = edges.Sum() - max;
            return sumOfOther2Edges > max;
        }
    }
}