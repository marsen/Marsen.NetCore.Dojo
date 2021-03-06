﻿using System;
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
            JsonSerializerOptions options) =>
            DateTime.ParseExact(reader.GetString() ?? string.Empty, "yyyy/MM/dd", CultureInfo.InvariantCulture);

        public override void Write(
            Utf8JsonWriter writer, 
            DateTime value, 
            JsonSerializerOptions options) =>
            throw new NotImplementedException();
    }
}