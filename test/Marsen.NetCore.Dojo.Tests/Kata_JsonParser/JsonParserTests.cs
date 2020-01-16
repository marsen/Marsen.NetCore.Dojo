using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata_JsonParser;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_JsonParser
{
    public class JsonParserTests : IDisposable
    {
        private readonly string _defaultTestJson = @"{ ""FirstName"": ""Tian"",
                                  ""LastName"": ""Tank"",
                                  ""BirthDate"": ""1989/06/04""
                                  }";

        private readonly PersonaParser _target = new PersonaParser();

        [Fact]
        public void ParseName()
        {
            AfterParseJson().Name.Should().Be("Tian Tank");
        }

        private PersonaEntity AfterParseJson()
        {
            return _target.Parse(_defaultTestJson);
        }

        [Fact]
        public void CovertAgeTodayIs2019()
        {
            GiveTodayIs("2019/12/28").Age.Should().Be(30);
        }

        [Fact]
        public void CovertAgeIfTodayIs2030()
        {
            GiveTodayIs("2030/05/06").Age.Should().Be(41);
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