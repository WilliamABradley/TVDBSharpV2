namespace TVDBSharp.Models
{
    /// <summary>
    /// Rating information from TVDB.
    /// </summary>
    public class TVDBRatingInfo
    {
        /// <summary>
        /// The average rating of the Show.
        /// </summary>
        public double? Average { get; set; }

        /// <summary>
        /// The number of ratings for the show.
        /// </summary>
        public ulong? Count { get; set; }
    }
}