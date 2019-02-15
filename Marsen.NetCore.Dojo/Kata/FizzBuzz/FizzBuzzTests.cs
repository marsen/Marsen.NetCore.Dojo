using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Kata
{
    public class FizzBuzzTests
    {
        [Fact(DisplayName = "1 回傳 1")]
        public void One_is_1()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            var actual = fizzBuzz.GetResult(1);
            Assert.Equal("1", actual);
        }
    }
}