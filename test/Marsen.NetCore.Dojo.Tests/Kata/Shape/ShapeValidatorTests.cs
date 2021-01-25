using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.Shape
{
    public class ShapeValidatorTests
    {
        private readonly ShapeValidator _validator = new();

        [Fact]
        public void The_3_3_3_Can_be_Triangle()
        {
            CanBeTriangle(3, 3, 3);
        }

        [Fact]
        public void The_6_3_3_Can_NOT_be_Triangle()
        {
            CanBeNotTriangle(6, 3, 3);
        }

        private void CanBeNotTriangle(int edge1, int edge2, int edge3)
        {
            Assert.False(_validator.IsTriangle(edge1, edge2, edge3));
        }

        private void CanBeTriangle(int edge1, int edge2, int edge3)
        {
            Assert.True(_validator.IsTriangle(edge1, edge2, edge3));
        }
    }

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