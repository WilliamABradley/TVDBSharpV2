using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TVDBSharp.Converters;
using TVDBSharp.Enums;

namespace TVDBSharp.Models
{
    public class TVDBSeriesQuery
    {
        public uint ID { get; set; }
        public string SeriesName { get; set; }
        public string Network { get; set; }

        public IReadOnlyCollection<string> Aliases { get; set; }

        public string Overview { get; set; }
        public string Banner { get; set; }

        [JsonConverter(typeof(StatusConverter))]
        public Status? Status { get; set; }

        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? FirstAired { get; set; }
    }
}