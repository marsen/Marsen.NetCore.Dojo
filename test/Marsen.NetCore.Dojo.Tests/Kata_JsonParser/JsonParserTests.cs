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
        private string json = "{" +
                              "\"FirstName\": \"Tian\"," +
                              "\"LastName\": \"Tank\"," +
                              "\"BirthDate\": \"1989/06/04\"" +
                              "}";

        private readonly PersonaParser _target = new PersonaParser();

        [Fact]
        public void CovertName()
        {
            ////Arrange

            ////Act
            var actual = _target.Parse(json).Name;
            ////Assert
            var expected = "Tian Tank";
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CovertAgeTodayIs2019()
        {
            ////Arrange
            SystemDateTime.Now = Convert.ToDateTime("2019/12/28");
            ////Act
            var actual = _target.Parse(json).Age;
            ////Assert
            var expected = 30;
            actual.Should().Be(expected);
        }


        [Fact]
        public void CovertAgeIfTodayIs2030()
        {
            ////Arrange
            SystemDateTime.Now = Convert.ToDateTime("2030/05/06");
            ////Act
            var actual = _target.Parse(json).Age;
            ////Assert
            var expected = 41;
            actual.Should().Be(expected);
        }

        public void Dispose()
        {
            SystemDateTime.Reset();
        }
    }
}