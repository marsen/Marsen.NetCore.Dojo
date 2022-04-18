using System.Text.Json;
using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Kata.JsonParser;

public class PersonaParser
{
    public PersonaEntity Parse(string json)
    {
        var serializeOptions = new JsonSerializerOptions();
        serializeOptions.Converters.Add(new DateTimeOffsetConverter());
        // https://docs.microsoft.com/zh-tw/dotnet/api/system.text.json.jsonserializeroptions.writeindented?view=net-5.0
        // here was serialize options write indented is true
        var originEntity = JsonSerializer.Deserialize<PersonaOriginEntity>(json, serializeOptions);
        var age = SystemDateTime.Now.Year - originEntity.BirthDate.Year;
        return new PersonaEntity
        {
            Age = age,
            Name = $"{originEntity.FirstName} {originEntity.LastName}"
        };
    }
}