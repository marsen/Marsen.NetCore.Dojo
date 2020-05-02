using System.Collections.Generic;
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
            Assert.Equal("A", _alphabet.Generate("A"));
        }

        [Fact]
        public void The_a_GetA()
        {
            Assert.Equal("A", _alphabet.Generate("a"));
        }
        
    }
}