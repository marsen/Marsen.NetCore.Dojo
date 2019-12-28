using System.Text.Json;
using System.Text.Json.Serialization;

namespace Marsen.NetCore.Dojo.Kata_JsonParser
{
    public class PersonaParser
    {
        public PersonaEntity Parse(string json)
        {
            var originEntity = JsonSerializer.Deserialize<PersonaOriginEntity>(json);
            return new PersonaEntity
            {
                Name = originEntity.FirstName + " " + originEntity.LastName
            };
        }
    }

    public class PersonaOriginEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}