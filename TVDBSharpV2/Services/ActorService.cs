using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVDBSharp.Models;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    public class ActorService : ScraperBase
    {
        public ActorService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        /// <summary>
        /// Fetches Episodes for a Series.
        /// </summary>
        /// <param name="SeriesID">Series to Fetch Episodes from</param>
        /// <returns>List of Episodes</returns>
        public async Task<IReadOnlyList<TVDBActor>> GetActors(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/actors");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBActorsResponse>(result).Data;
        }
    }
}