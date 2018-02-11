namespace TVDBSharp.Models
{
    /// <summary>
    /// Artwork Information for a Series.
    /// </summary>
    public class TVDBArtwork
    {
        /// <summary>
        /// The TVDB ID for this artwork.
        /// </summary>
        public uint ID { get; set; }

        /// <summary>
        /// The Image Url for this Artwork.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The Type of Artwork this is.
        /// </summary>
        public string KeyType { get; set; }

        /// <summary>
        /// The TVDB Language ID this is, if there is text in it.
        /// </summary>
        public uint? LanguageID { get; set; }

        /// <summary>
        /// The rating of this Artwork.
        /// </summary>
        public TVDBRatingInfo RatingsInfo { get; set; }

        /// <summary>
        /// The Thumbnail of this Artwork.
        /// </summary>
        public string Thumbnail { get; set; }
    }
}