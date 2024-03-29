﻿using System;
using System.Linq;
using ExpectedObjects;
using Marsen.NetCore.Dojo.Classes.Joey.ShowHands;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.ShowHands
{
    public class CardParserTests
    {
        private readonly CardParser _cardParser = new();

        private ExpectedObject Parser(string input)
        {
            return input.Split(',').Select(x => new Card
            {
                Rank = int.Parse(x.Substring(1)),
                Suit = Enum.Parse<Suit>(x.Substring(0, 1))
            }).ToList().ToExpectedObject();
        }

        [Fact]
        public void Parse_Four_Of_a_Kind()
        {
            var input = "S3,C3,D3,H3,H7";
            var actual = _cardParser.Parse(input);
            var expected = Parser(input);
            expected.ShouldEqual(actual);
        }


        [Fact]
        public void Parse_Three_Of_a_Kind()
        {
            var input = "S3,C3,D3,H7,H8";
            var actual = _cardParser.Parse(input);
            var expected = Parser(input);
            expected.ShouldEqual(actual);
        }
    }
}