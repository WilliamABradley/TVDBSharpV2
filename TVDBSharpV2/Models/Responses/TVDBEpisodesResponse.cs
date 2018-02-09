using System.Collections.Generic;

namespace TVDBSharp.Models.Responses
{
    public class TVDBEpisodesResponse
    {
        public TVDBPagingData Links { get; set; }
        public List<TVDBEpisodeSummary> Data { get; set; }
    }
}