using System.Collections.Generic;
using Marsen.NetCore.Dojo.Classes.Joey.Alphabet;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Alphabet
{
    public class AlphabetTests
    {
        [Fact]
        public void AGetA()
        {
            var alphabet = new AlphabetGame();
            Assert.Equal("A",alphabet.Generate());
        }
    }
}