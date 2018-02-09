using System.Collections.Generic;

namespace TVDBSharp.Models.Responses
{
    public class TVDBSeriesUpdatesResponse
    {
        public IReadOnlyCollection<TVDBUpdate> data { get; set; }
    }
}