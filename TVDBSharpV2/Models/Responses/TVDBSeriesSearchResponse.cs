using System.Collections.Generic;

namespace TVDBSharp.Models.Responses
{
    internal class TVDBSeriesSearchResponse
    {
        public IReadOnlyCollection<TVDBSeriesQuery> Data { get; set; }
    }
}