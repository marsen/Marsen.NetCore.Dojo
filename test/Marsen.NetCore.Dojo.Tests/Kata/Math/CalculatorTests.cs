using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.Math
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_1_1_is_2()
        {
            var target = new Calculator();
            Assert.Equal(2, target.Add(1, 1));
        }

        [Fact]
        public void Add_2_1_is_3()
        {
            var target = new Calculator();
            Assert.Equal(3, target.Add(2, 1));
        }
    }

    public class Calculator
    {
        public int Add(int first, int second)
        {
            return first + second;
        }
    }
}