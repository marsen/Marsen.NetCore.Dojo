using System.Text.Json;
using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Kata.JsonParser
{
    public class PersonaParser
    {
        public PersonaEntity Parse(string json)
        {
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new DateTimeOffsetConverter());
            serializeOptions.WriteIndented = true;
            var originEntity = JsonSerializer.Deserialize<PersonaOriginEntity>(json, serializeOptions);
            var age = SystemDateTime.Now.Year - originEntity.BirthDate.Year;
            return new PersonaEntity
            {
                Age = age,
                Name = originEntity.FirstName + " " + originEntity.LastName
            };
        }
    }
}