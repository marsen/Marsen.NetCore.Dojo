using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.Shape
{
    public class ShapeValidatorTests
    {
        private ShapeValidator _validator;

        [Fact]
        public void The_3_3_3_Can_be_Triangle()
        {
            _validator = new ShapeValidator();
            Assert.True(_validator.IsTriangle(3, 3, 3));
        }

        [Fact]
        public void The_6_3_3_Can_NOT_be_Triangle()
        {
            _validator = new ShapeValidator();
            Assert.False(_validator.IsTriangle(6, 3, 3));
        }
    }

    public class ShapeValidator
    {
        public bool IsTriangle(int line1, int line2, int line3)
        {
            return line2 + line3 > line1;
        }
    }
}