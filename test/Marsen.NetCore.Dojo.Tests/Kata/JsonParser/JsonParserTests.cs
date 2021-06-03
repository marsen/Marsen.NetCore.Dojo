using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.JsonParser;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.JsonParser
{
    public class JsonParserTests : IDisposable
    {
        private readonly PersonaParser _target = new();

        [Fact]
        public void parse_name()
        {
            Tian_Tank_1989_06_04().Name.Should().Be("Tian Tank");
        }

        [Fact]
        public void parse_age_today_is_2019()
        {
            ////Arrange
            SystemDateTime.Now = Convert.ToDateTime("2019/12/28");
            ////Act
            Tian_Tank_1989_06_04().Age.Should().Be(30);
        }

        [Fact]
        public void parse_age_today_is_2030()
        {
            ////Arrange
            SystemDateTime.Now = Convert.ToDateTime("2030/05/06");
            ////Act
            Tian_Tank_1989_06_04().Age.Should().Be(41);
        }

        private PersonaEntity Tian_Tank_1989_06_04()
        {
            return _target.Parse(@"{
                    'FirstName': 'Tian',
                    'LastName': 'Tank',
                    'BirthDate': '1989/06/04'
                }".Replace(@"'", @""""));
        }

        public void Dispose()
        {
            SystemDateTime.Reset();
        }
    }
}