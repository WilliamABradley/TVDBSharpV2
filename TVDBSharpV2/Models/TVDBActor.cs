using Newtonsoft.Json;
using System;
using TVDBSharp.Converters;

namespace TVDBSharp.Models
{
    public class TVDBActor
    {
        public uint ID { get; set; }
        public uint SeriesID { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }

        public int SortOrder { get; set; }

        public string Image { get; set; }
        public uint? ImageAuthor { get; set; }

        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? ImageAdded { get; set; }

        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? LastUpdated { get; set; }
    }
}