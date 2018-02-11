using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TVDBSharp.Enums;
using TVDBSharp.Converters;
using Newtonsoft.Json.Converters;

namespace TVDBSharp.Models
{
    /// <summary>
    /// Series Information.
    /// </summary>
    public class TVDBSeries
    {
        /// <summary>
        /// The TVDB ID for the Series.
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// The IMDB ID for the Series.
        /// </summary>
        public string IMDBID { get; set; }

        /// <summary>
        /// The Name of the Series.
        /// </summary>
        public string SeriesName { get; set; }

        /// <summary>
        /// The Aliases for the Series Name.
        /// </summary>
        public IReadOnlyCollection<string> Aliases { get; set; }

        /// <summary>
        /// The Genres that this Series belongs to.
        /// </summary>
        [JsonProperty("genre")]
        public IReadOnlyCollection<string> Genres { get; set; }

        /// <summary>
        /// The Network this Series belongs to.
        /// </summary>
        public string Network { get; set; }

        /// <summary>
        /// The Network ID that this Series belongs to.
        /// </summary>
        public string NetworkID { get; set; }

        /// <summary>
        /// The Banner Image Url string for this Series.
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// The Poster Image Url string for this Series.
        /// </summary>
        public string Poster { get; set; }

        /// <summary>
        /// The Fanart Image Url string for this Series.
        /// </summary>
        public string Fanart { get; set; }

        /// <summary>
        /// The Overview of this Series.
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// The average rating for this Series on TVDB.
        /// </summary>
        public double? SiteRating { get; set; }

        /// <summary>
        /// The number of ratings of this Series on TVDB.
        /// </summary>
        public ulong? SiteRatingCount { get; set; }

        /// <summary>
        /// The Content Rating of this Series, in US format.
        /// </summary>
        [JsonProperty("rating")]
        public string ContentRating { get; set; }

        /// <summary>
        /// The time of the Day that this series airs on.
        /// </summary>
        [JsonProperty("AirsTime")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? AirTime { get; set; }

        /// <summary>
        /// The time this show runs for in minutes.
        /// </summary>
        public uint? Runtime { get; set; }

        /// <summary>
        /// The current Status of this Series.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Status? Status { get; set; }

        /// <summary>
        /// The day(s) this show Airs.
        /// </summary>
        [JsonProperty("airsDayOfWeek")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AirDay? AirDay { get; set; }

        /// <summary>
        /// The date this show first aired.
        /// </summary>
        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? FirstAired { get; set; }

        /// <summary>
        /// The date this show information was last updated.
        /// </summary>
        [JsonConverter(typeof(EpochTimeConverter))]
        public DateTimeOffset? LastUpdated { get; set; }

        /// <summary>
        /// The date this show was added to TVDB.
        /// </summary>
        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? Added { get; set; }

        /// <summary>
        /// The TVDB User ID who added this show to TVDB.
        /// </summary>
        public uint? AddedBy { get; set; }
    }
}