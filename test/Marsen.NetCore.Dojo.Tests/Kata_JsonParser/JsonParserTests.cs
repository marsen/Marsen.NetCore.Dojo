using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata_JsonParser;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_JsonParser
{
    public class JsonParserTests
    {
        [Fact]
        public void CovertFirstName()
        {
            ////Arrange
            var json = @"
            { 
                'FirstName': 'Tian',
                'LastName': 'Tank',
                'BirthDate': '1989/06/04'
            }";
            var parser = new PersonaParser();
            ////Act
            var actual = parser.Parse(json);
            ////Assert
            var expected = new PersonaEntity
            {
                Age = 30,
                Name = "Tian Tank"
            };
            actual.Should().BeEquivalentTo(expected);
        }
    }
}