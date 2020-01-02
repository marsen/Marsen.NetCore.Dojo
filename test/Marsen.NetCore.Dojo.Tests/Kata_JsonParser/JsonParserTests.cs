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
        private string testJson = "{" +
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
            var actual = _target.Parse(testJson).Name;
            ////Assert
            actual.Should().BeEquivalentTo("Tian Tank");
        }

        [Fact]
        public void CovertAgeTodayIs2019()
        {
            ////Arrange
            SystemDateTime.Now = Convert.ToDateTime("2019/12/28");
            ////Act
            var actual = _target.Parse(testJson).Age;
            ////Assert
            actual.Should().Be(30);
        }


        [Fact]
        public void CovertAgeIfTodayIs2030()
        {
            ////Arrange
            SystemDateTime.Now = Convert.ToDateTime("2030/05/06");
            ////Act
            var actual = _target.Parse(testJson).Age;
            ////Assert
            actual.Should().Be(41);
        }

        public void Dispose()
        {
            SystemDateTime.Reset();
        }
    }
}