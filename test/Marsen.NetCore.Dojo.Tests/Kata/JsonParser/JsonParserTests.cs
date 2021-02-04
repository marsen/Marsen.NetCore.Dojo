using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.JsonParser;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.JsonParser
{
    public class JsonParserTests : IDisposable
    {
        private readonly string _defaultTestJson = @"{ 
                                  ""FirstName"": ""Tian"",
                                  ""LastName"": ""Tank"",
                                  ""BirthDate"": ""1989/06/04""
                                  }";

        private readonly PersonaParser _target = new();

        [Fact]
        public void parse_name()
        {
            AfterParseJson().Name.Should().Be("Tian Tank");
        }

        [Fact]
        public void parse_age_today_is_2019()
        {
            GiveTodayIs("2019/12/28").Age.Should().Be(30);
        }

        [Fact]
        public void parse_age_today_is_2030()
        {
            GiveTodayIs("2030/05/06").Age.Should().Be(41);
        }

        private PersonaEntity AfterParseJson()
        {
            return _target.Parse(_defaultTestJson);
        }

        private PersonaEntity GiveTodayIs(string date)
        {
            ////Arrange
            SystemDateTime.Now = Convert.ToDateTime(date);
            ////Act
            return AfterParseJson();
        }

        public void Dispose()
        {
            SystemDateTime.Reset();
        }
    }
}