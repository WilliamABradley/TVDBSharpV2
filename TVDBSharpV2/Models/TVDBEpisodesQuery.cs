using System.Collections.Generic;

namespace TVDBSharp.Models
{
    /// <summary>
    /// Episode Query of this Series.
    /// </summary>
    public class TVDBEpisodesQuery
    {
        /// <summary>
        /// The Aired Seasons this Series contains.
        /// </summary>
        public IReadOnlyCollection<string> AiredSeasons { get; set; }

        /// <summary>
        /// The Aired Episodes information.
        /// </summary>
        public string AiredEpisodes { get; set; }

        /// <summary>
        /// The DVD Seasons this Series contains.
        /// </summary>
        public IReadOnlyCollection<string> DVDSeasons { get; set; }

        /// <summary>
        /// The DVD Episodes information.
        /// </summary>
        public string DVDEpisodes { get; set; }
    }
}