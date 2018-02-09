using System.Collections.Generic;

namespace TVDBSharp.Models.Responses
{
    public class TVDBSeriesSearchResponse
    {
        public IReadOnlyCollection<TVDBSeriesQuery> Data { get; set; }
    }
}