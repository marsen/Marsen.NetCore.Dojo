using System;
using System.Collections.Generic;
using System.Text;
using Marsen.NetCore.Dojo.Kata_FizzBuzz;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_FizzBuzz
{
    public class FizzBuzzTests
    {
        private readonly FizzBuzz _fizzBuzz = new FizzBuzz();

        [Fact]
        public void one_is_1()
        {
            var actual = _fizzBuzz.Get(1);
            Assert.Equal("1", actual);
        }

        [Fact]
        public void tow_is_2()
        {
            var actual = _fizzBuzz.Get(2);
            Assert.Equal("2", actual);
        }

        [Fact]
        public void three_is_3()
        {
            var actual = _fizzBuzz.Get(3);
            Assert.Equal("Fizz", actual);
        }
    }
}