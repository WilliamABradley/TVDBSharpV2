using Newtonsoft.Json;
using System;
using TVDBSharp.Enums;

namespace TVDBSharp.Converters
{
    public class AirDayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;
            return !string.IsNullOrWhiteSpace(value) ? Enum.Parse(typeof(AirDay), value) : null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}