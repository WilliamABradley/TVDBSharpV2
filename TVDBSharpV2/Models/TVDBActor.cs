using Newtonsoft.Json;
using System;
using TVDBSharp.Converters;

namespace TVDBSharp.Models
{
    /// <summary>
    /// Actor Information for a Series.
    /// </summary>
    public class TVDBActor
    {
        /// <summary>
        /// The TVDB ID for this Actor (Unique for each Series only).
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// The Series this Actor is in relation to.
        /// </summary>
        public uint SeriesID { get; set; }

        /// <summary>
        /// The Name of the Actor.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Actor's role in this Series.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The priority of this Actor in the order of the Actors list.
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// The Image Url for this Actor in this Series.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The TVDB User who provided the Image.
        /// </summary>
        public uint? ImageAuthor { get; set; }

        /// <summary>
        /// The Date this image was added to TVDB.
        /// </summary>
        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? ImageAdded { get; set; }

        /// <summary>
        /// The date this Actor Information was last updated.
        /// </summary>
        [JsonConverter(typeof(StringDateConverter))]
        public DateTime? LastUpdated { get; set; }
    }
}