using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVDBSharp.Models;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    public class EpisodesService : ScraperBase
    {
        public EpisodesService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        /// <summary>
        /// Fetches Episodes for a Series.
        /// </summary>
        /// <param name="SeriesID">Series to Fetch Episodes from</param>
        /// <returns>List of Episodes</returns>
        public async Task<IReadOnlyList<TVDBEpisodeSummary>> GetEpisodes(uint SeriesID)
        {
            int page = 1;
            List<TVDBEpisodeSummary> Episodes = new List<TVDBEpisodeSummary>();
            while (true)
            {
                var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/episodes?page={page}");
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<TVDBEpisodesResponse>(result);

                Episodes.AddRange(data.Data);

                if (data.Links.Next == null) break;
                page++;
            }
            return Episodes.OrderBy(item => item.SeasonNumber).ThenBy(item => item.EpisodeNumber).ToList();
        }

        public async Task<TVDBEpisode> GetEpisode(uint EpisodeID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/episodes/{EpisodeID}");
            var result = await response.Content.ReadAsStringAsync();
            var episode = JsonConvert.DeserializeObject<TVDBEpisodeResponse>(result).Data;
            return episode;
        }
    }
}