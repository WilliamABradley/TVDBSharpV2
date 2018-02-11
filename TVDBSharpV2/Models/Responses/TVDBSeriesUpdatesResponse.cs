using System.Collections.Generic;

namespace TVDBSharp.Models.Responses
{
    internal class TVDBSeriesUpdatesResponse
    {
        public IReadOnlyCollection<TVDBUpdate> Data { get; set; }
    }
}