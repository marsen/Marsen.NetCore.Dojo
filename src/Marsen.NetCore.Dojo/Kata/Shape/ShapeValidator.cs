using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.Shape
{
    public class ShapeValidator
    {
        public bool IsTriangle(int edge1, int edge2, int edge3)
        {
            var edges = new List<int> { edge1, edge2, edge3 };
            return edges.Sum() - edges.Max() > edges.Max();
        }
    }
}