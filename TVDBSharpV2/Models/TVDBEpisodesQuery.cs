using System.Collections.Generic;

namespace TVDBSharp.Models
{
    public class TVDBEpisodesQuery
    {
        public IReadOnlyCollection<string> AiredSeasons { get; set; }
        public string AiredEpisodes { get; set; }

        public IReadOnlyCollection<string> DVDSeasons { get; set; }
        public string DVDEpisodes { get; set; }
    }
}
