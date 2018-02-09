using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVDBSharp.Common;
using TVDBSharp.Models;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    public class UpdateService : ScraperBase
    {
        public UpdateService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        public async Task<IReadOnlyCollection<TVDBUpdate>> GetSeriesUpdates(DateTime fromTime, DateTime? toTime = null)
        {
            if (!toTime.HasValue) toTime = fromTime.AddDays(7);
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/updated/query?fromTime={fromTime.ToEpoch()}&toTime{toTime.Value.ToEpoch()}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBSeriesUpdatesResponse>(result).data;
        }

        public async Task<DateTimeOffset?> GetLastUpdatedForSeries(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/filter?keys=lastUpdated");
            return response.Content.Headers.LastModified;
        }
    }
}