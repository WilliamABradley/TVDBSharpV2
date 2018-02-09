using Newtonsoft.Json;
using System;
using TVDBSharp.Common;

namespace TVDBSharp.Converters
{
    public class EpochTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (long)reader.Value;
            return DateTimeExtensions.ToDateTime(value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}