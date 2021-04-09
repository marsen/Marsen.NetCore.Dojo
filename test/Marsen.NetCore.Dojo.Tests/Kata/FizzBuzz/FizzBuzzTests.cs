using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.FizzBuzz
{
    public class FizzBuzzTests
    {
        private readonly Dojo.Kata.FizzBuzz.FizzBuzz _fizzBuzz = new();

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

        [Fact]
        public void four_is_4()
        {
            var actual = _fizzBuzz.Get(4);
            Assert.Equal("4", actual);
        }

        [Fact]
        public void five_is_5()
        {
            var actual = _fizzBuzz.Get(5);
            Assert.Equal("Buzz", actual);
        }

        [Fact]
        public void six_is_Fizz()
        {
            var actual = _fizzBuzz.Get(6);
            Assert.Equal("Fizz", actual);
        }

        [Fact]
        public void fifteen_is_FizzBuzz()
        {
            var actual = _fizzBuzz.Get(15);
            Assert.Equal("FizzBuzz", actual);
        }
    }
}