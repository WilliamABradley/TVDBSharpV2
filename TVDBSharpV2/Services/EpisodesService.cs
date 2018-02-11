using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVDBSharp.Models;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    /// <summary>
    /// Methods relating to fetching Episode information for a Series.
    /// </summary>
    public class EpisodesService : ServiceBase
    {
        internal EpisodesService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        /// <summary>
        /// Queries Episodes for a Series.
        /// </summary>
        /// <param name="SeriesID">Series to Query Episodes from</param>
        /// <returns>Episode information for Series</returns>
        public async Task<TVDBEpisodesQuery> QueryEpisodes(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/episodes/summary");
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<TVDBEpisodesQueryResponse>(result).Data;
            return data;
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

        /// <summary>
        /// Gets a singular Episode from it's Episode ID.
        /// </summary>
        /// <param name="EpisodeID">Episode ID</param>
        /// <returns>Episode Information</returns>
        public async Task<TVDBEpisode> GetEpisode(uint EpisodeID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/episodes/{EpisodeID}");
            var result = await response.Content.ReadAsStringAsync();
            var episode = JsonConvert.DeserializeObject<TVDBEpisodeResponse>(result).Data;
            return episode;
        }
    }
}