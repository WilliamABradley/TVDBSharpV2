using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TVDBSharp.Enums;
using TVDBSharp.Converters;

namespace TVDBSharp.Models
{
    public class TVDBSeries
    {
        public uint ID { get; set; }
        public string IMDBID { get; set; }

        public string SeriesName { get; set; }

        public IReadOnlyCollection<string> Aliases { get; set; }

        [JsonProperty("genre")]
        public IReadOnlyCollection<string> Genres { get; set; }

        public string Network { get; set; }
        public string NetworkID { get; set; }

        public string Banner { get; set; }
        public string Poster { get; set; }
        public string Fanart { get; set; }

        public string Overview { get; set; }

        public double? SiteRating { get; set; }
        public ulong? SiteRatingCount { get; set; }

        [JsonProperty("rating")]
        public string ContentRating { get; set; }

        [JsonProperty("AirsTime")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? AirTime { get; set; }

        public uint? Runtime { get; set; }

        [JsonConverter(typeof(StatusConverter))]
        public Status? Status { get; set; }

        [JsonProperty("airsDayOfWeek")]
        [JsonConverter(typeof(AirDayConverter))]
        public AirDay? AirDay { get; set; }

        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? FirstAired { get; set; }

        [JsonConverter(typeof(EpochTimeConverter))]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? Added { get; set; }

        public uint? AddedBy { get; set; }
    }
}