using System.Collections.Generic;
using ExpectedObjects;
using Marsen.NetCore.Dojo.Kata_ShowHands;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_ShowHands
{
    public class CardParserTests
    {
        private readonly CardParser _cardParser = new CardParser();

        [Fact]
        public void Parse_Four_Of_a_Kind()
        {
            var input = "S3,C3,D3,H3,H7";
            var actual = _cardParser.Parse(input);
            var expected = new List<Card>
            {
                new Card {Rank = 3},
                new Card {Rank = 3},
                new Card {Rank = 3},
                new Card {Rank = 3},
                new Card {Rank = 7},
            }.ToExpectedObject();
            expected.ShouldEqual(actual);
        }
    }
}