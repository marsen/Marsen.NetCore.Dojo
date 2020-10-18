using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.Math
{
    public class CalculatorTests
    {
        private readonly Calculator _target = new Calculator();

        [Fact]
        public void Add_1_1_is_2()
        {
            Assert.Equal(2, _target.Add(1, 1));
        }

        [Fact]
        public void Add_2_1_is_3()
        {
            Assert.Equal(3, _target.Add(2, 1));
        }

        [Fact]
        public void Subtract_2_1_is_3()
        {
            Assert.Equal(1, _target.Subtract(2, 1));
        }
    }

    public class Calculator
    {
        public int Add(int first, int second)
        {
            return first + second;
        }

        public int Subtract(int first, int second)
        {
            return first - second;
        }
    }
}