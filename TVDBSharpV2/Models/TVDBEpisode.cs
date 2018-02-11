using Newtonsoft.Json;
using System;
using TVDBSharp.Converters;

namespace TVDBSharp.Models
{
    /// <summary>
    /// Episode Information.
    /// </summary>
    public class TVDBEpisode
    {
        /// <summary>
        /// The TVDB ID for this Episode.
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// The Series this Episode belongs to.
        /// </summary>
        [JsonIgnore]
        public uint SeriesID { get; set; }

        /// <summary>
        /// The Title of this Episode.
        /// </summary>
        [JsonProperty("episodeName")]
        public string Title { get; set; }

        /// <summary>
        /// The Season Number of this Episode.
        /// </summary>
        [JsonProperty("airedSeason")]
        public uint SeasonNumber { get; set; }

        /// <summary>
        /// The Episode Number of this Episode in the Season.
        /// </summary>
        [JsonProperty("airedEpisodeNumber")]
        public uint EpisodeNumber { get; set; }

        /// <summary>
        /// The Absolute Episode Number for the entire Series.
        /// </summary>
        [JsonProperty("absoluteNumber")]
        public uint? AbsoluteEpisodeNumber { get; set; }

        /// <summary>
        /// The Season number of this Episode on DVD.
        /// </summary>
        public uint? DVDSeason { get; set; }

        /// <summary>
        /// The Episode Number of this Episode in the DVD Season.
        /// </summary>
        public uint? DVDEpisodeNumber { get; set; }

        /// <summary>
        /// The overview of this Episode.
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// The Date this Episode first aired.
        /// </summary>
        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? FirstAired { get; set; }

        /// <summary>
        /// The Date this Episode's information was last updated.
        /// </summary>
        [JsonConverter(typeof(EpochTimeConverter))]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("SeriesID")]
        private string _SeriesID
        {
            get { return SeriesID.ToString(); }
            set { SeriesID = Convert.ToUInt32(value); }
        }
    }
}