using Newtonsoft.Json;
using System;
using System.Globalization;

namespace TVDBSharp.Converters
{
    public class StringDateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;
            if (!string.IsNullOrWhiteSpace(value))
            {
                try
                {
                    return DateTime.Parse(value, CultureInfo.InvariantCulture);
                }
                catch { }
                return null;
            }
            else
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}