using System;
using System.Text.Json;

namespace Marsen.NetCore.Dojo.Kata_JsonParser
{
    public class PersonaParser
    {
        public PersonaEntity Parse(string json)
        {
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new DateTimeOffsetConverter());
            serializeOptions.WriteIndented = true;
            var originEntity = JsonSerializer.Deserialize<PersonaOriginEntity>(json,serializeOptions);
            var age = DateTime.Now.Year - originEntity.BirthDate.Year;
            return new PersonaEntity
            {
                Age = age,
                Name = originEntity.FirstName + " " + originEntity.LastName
            };
        }
    }
}