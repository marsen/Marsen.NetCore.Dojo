using System;
using System.Collections.Generic;
using System.Text;
using Marsen.NetCore.Dojo.Kata_FizzBuzz;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_FizzBuzz
{
    public class FizzBuzzTests
    {
        [Fact]
        public void one_is_1()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            var actual = fizzBuzz.Get(1);
            Assert.Equal("1", actual);
        }
    }
}