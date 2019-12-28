using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

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

    public class PersonaOriginEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class DateTimeOffsetConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            DateTime.ParseExact(reader.GetString(), "yyyy/MM/dd",CultureInfo.InvariantCulture);

        public override void Write(
            Utf8JsonWriter writer,
            DateTime value,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString(
                "yyyy/MM/dd", CultureInfo.InvariantCulture));
    }
}