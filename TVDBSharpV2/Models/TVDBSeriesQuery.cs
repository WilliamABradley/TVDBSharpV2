using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using TVDBSharp.Converters;
using TVDBSharp.Enums;

namespace TVDBSharp.Models
{
    /// <summary>
    /// Basic Series Information for a Query.
    /// </summary>
    public class TVDBSeriesQuery
    {
        /// <summary>
        /// The TVDB ID for the Series.
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// The Name of the Series.
        /// </summary>
        public string SeriesName { get; set; }

        /// <summary>
        /// The Network this Series belongs to.
        /// </summary>
        public string Network { get; set; }

        /// <summary>
        /// The Aliases for the Series Name.
        /// </summary>
        public IReadOnlyCollection<string> Aliases { get; set; }

        /// <summary>
        /// The Overview of this Series.
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// The Banner Image Url string for this Series.
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// The current Status of this Series.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Status? Status { get; set; }

        /// <summary>
        /// The date this show first aired.
        /// </summary>
        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? FirstAired { get; set; }
    }
}