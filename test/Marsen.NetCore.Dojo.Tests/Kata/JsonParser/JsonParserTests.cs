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

        public void Dispose()
        {
            SystemDateTime.Reset();
        }

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

        [Fact]
        public void person_without_birthday()
        {
            Action act = () => _target.Parse(@"{
                    'FirstName': 'Tian',
                    'LastName': 'Tank',
                    'BirthDate': ''
                }".Replace(@"'", @""""));
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void person_wrong_birthday()
        {
            Action act = () => _target.Parse(@"{
                            'FirstName': 'Tina',
                            'LastName': 'Tank',
                            'BirthDate': 'Wrong'
                        }".Replace(@"'", @""""));
            act.Should().Throw<InvalidOperationException>();
        }


        private PersonaEntity Tian_Tank_1989_06_04()
        {
            return _target.Parse(@"{
                    'FirstName': 'Tian',
                    'LastName': 'Tank',
                    'BirthDate': '1989/06/04'
                }".Replace(@"'", @""""));
        }
    }
}