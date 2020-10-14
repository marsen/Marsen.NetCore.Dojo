using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.Math
{
    public class CalculatorTests
    {

        [Fact]
        public void Add_1_1_is_2()
        {
            var target = new Calculator();
            Assert.Equal(2,target.Add(1,1));
        }
    }

    public class Calculator
    {
        public int Add(int first, int second)
        {
            throw new System.NotImplementedException();
        }
    }
}