using Newtonsoft.Json;
using System;
using TVDBSharp.Converters;

namespace TVDBSharp.Models
{
    public class TVDBEpisodeSummary
    {
        public uint ID { get; set; }

        [JsonProperty("episodeName")]
        public string Title { get; set; }

        [JsonProperty("airedSeason")]
        public uint SeasonNumber { get; set; }

        [JsonProperty("airedEpisodeNumber")]
        public uint EpisodeNumber { get; set; }

        [JsonProperty("absoluteNumber")]
        public uint? AbsoluteEpisodeNumber { get; set; }

        public uint? DVDSeason { get; set; }
        public uint? DVDEpisodeNumber { get; set; }

        public string Overview { get; set; }

        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? FirstAired { get; set; }

        [JsonConverter(typeof(EpochTimeConverter))]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}