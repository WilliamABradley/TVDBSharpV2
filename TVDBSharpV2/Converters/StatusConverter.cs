using Newtonsoft.Json;
using System;
using TVDBSharp.Enums;

namespace TVDBSharp.Converters
{
    public class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;
            return !string.IsNullOrWhiteSpace(value) ? Enum.Parse(typeof(Status), value) : null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}