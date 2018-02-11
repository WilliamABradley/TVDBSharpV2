using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVDBSharp.Common;
using TVDBSharp.Models;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    /// <summary>
    /// Methods relating to Updates to information from TVDB.
    /// </summary>
    public class UpdateService : ServiceBase
    {
        internal UpdateService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        /// <summary>
        /// Gets Series updates from the Specified FromTime. If ToTime isn't specified, it collects 7 days worth of Updates.
        /// </summary>
        /// <param name="FromTime">Updated From</param>
        /// <param name="ToTime">Updated to</param>
        /// <returns>Updated Series.</returns>
        public async Task<IReadOnlyCollection<TVDBUpdate>> GetSeriesUpdates(DateTime FromTime, DateTime? ToTime = null)
        {
            if (!ToTime.HasValue) ToTime = FromTime.AddDays(7);
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/updated/query?fromTime={FromTime.ToEpoch()}&toTime{ToTime.Value.ToEpoch()}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBSeriesUpdatesResponse>(result).Data;
        }

        /// <summary>
        /// Gets the last time the Series was updated.
        /// </summary>
        /// <param name="SeriesID">Series ID to query.</param>
        /// <returns>Time last updated.</returns>
        public async Task<DateTimeOffset?> GetLastUpdatedForSeries(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/filter?keys=lastUpdated");
            return response.Content.Headers.LastModified;
        }
    }
}