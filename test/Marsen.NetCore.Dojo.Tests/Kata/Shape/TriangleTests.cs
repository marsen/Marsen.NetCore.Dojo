using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.Shape
{
    public class TriangleTests
    {
        [Fact]
        public void The_3_3_3_Can_be_Triangle()
        {
            Triangle triangle = new Triangle();
            Assert.True(triangle.IsTriangle(3, 3, 3));
        }
    }

    public class Triangle
    {
        public bool IsTriangle(int line1, int line2, int line3)
        {
            return true;
        }
    }
}