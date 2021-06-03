using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Marsen.NetCore.Dojo.Kata.JsonParser
{
    public class DateTimeOffsetConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (DateTime.TryParse(reader.GetString(), out var dateTime))
            {
                return dateTime;
            }

            throw new InvalidOperationException();
        }

        public override void Write(
            Utf8JsonWriter writer, 
            DateTime value, 
            JsonSerializerOptions options) =>
            throw new NotImplementedException();
    }
}