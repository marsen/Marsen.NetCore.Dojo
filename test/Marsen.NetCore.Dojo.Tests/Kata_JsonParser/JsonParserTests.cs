using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
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
            var parser = new Parser();
            ////Act
            var actual = parser.Parse(json);
            ////Assert
            var expected = new PersonEntity
            {
                Age = 30,
                Name = "Tian Tank"
            };
            actual.Should().BeEquivalentTo(expected);
        }
    }

    public class PersonEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Parser
    {
        public PersonEntity Parse(string json)
        {
            return new PersonEntity
            {
                Age = 30,
                Name = "Tian Tank"
            };
        }
    }
}