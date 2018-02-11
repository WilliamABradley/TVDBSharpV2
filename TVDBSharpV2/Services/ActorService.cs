using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVDBSharp.Models;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    /// <summary>
    /// Methods relating to Actor Information.
    /// </summary>
    public class ActorService : ServiceBase
    {
        internal ActorService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        /// <summary>
        /// Fetches Actors for a Series.
        /// </summary>
        /// <param name="SeriesID">Series to Fetch Actors from</param>
        /// <returns>List of Actors</returns>
        public async Task<IReadOnlyList<TVDBActor>> GetActors(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/actors");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBActorsResponse>(result).Data;
        }
    }
}