using System.Collections.Generic;
using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.Alphabet;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Alphabet
{
    public class AlphabetTests
    {
        private readonly AlphabetGame _alphabet = new AlphabetGame();

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
    }
}