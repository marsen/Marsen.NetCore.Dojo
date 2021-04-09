using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005.Plus;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.Plus
{
    public class AlphabetTests
    {
        private readonly AlphabetGame _alphabet = new();

        [Fact]
        public void The_A_GetA()
        {
            _alphabet.Generate("A").Should().Be("A");
        }

        [Fact]
        public void The_a_GetA()
        {
            _alphabet.Generate("a").Should().Be("A");
        }

        [Fact]
        public void The_ab_Get_A_Bb()
        {
            _alphabet.Generate("ab").Should().Be("A-Bb");
        }

        [Fact]
        public void The_abc_Get_A_Bb_Ccc()
        {
            _alphabet.Generate("abc").Should().Be("A-Bb-Ccc");
        }

        [Fact]
        public void The_a3_Get_A_33()
        {
            _alphabet.Generate("a3").Should().Be("A-33");
        }
    }
}