using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVDBSharp.Models;
using TVDBSharp.Models.Requests;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    /// <summary>
    /// Methods relating to fetching Series Information.
    /// </summary>
    public class SeriesService : ServiceBase
    {
        internal SeriesService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        /// <summary>
        /// Searches for Series based on the Title.
        /// </summary>
        /// <param name="query">Series Title Query</param>
        /// <returns>List of Series results</returns>
        public async Task<IReadOnlyCollection<TVDBSeriesQuery>> FindSeries(string query)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/search/series?name={query}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBSeriesSearchResponse>(result).Data;
        }

        /// <summary>
        /// Gets Series Information for the Series ID.
        /// </summary>
        /// <param name="SeriesID">Series ID of Series</param>
        /// <param name="IncludeArtwork">Include Artwork in the Request?</param>
        /// <returns>Series Information</returns>
        public async Task<TVDBSeries> GetSeries(uint SeriesID, bool IncludeArtwork = false)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}");
            var result = await response.Content.ReadAsStringAsync();
            var series = JsonConvert.DeserializeObject<TVDBSeriesResponse>(result).Data;

            if (IncludeArtwork)
            {
                var posters = await GetSeriesPosters(SeriesID);
                var fanarts = await GetSeriesFanart(SeriesID);

                var poster = posters.OrderBy(item => item.RatingsInfo.Average)
                    .ThenBy(item => item.RatingsInfo.Count)
                    .FirstOrDefault();

                var fanart = fanarts.OrderBy(item => item.RatingsInfo.Average)
                    .ThenBy(item => item.RatingsInfo.Count)
                    .FirstOrDefault();

                series.Poster = poster?.FileName;
                series.Fanart = fanart?.FileName;
            }

            return series;
        }

        /// <summary>
        /// Gets the Posters for this Series.
        /// </summary>
        /// <param name="SeriesID">Series to get Posters for.</param>
        /// <returns>List of Posters</returns>
        public async Task<IReadOnlyList<TVDBArtwork>> GetSeriesPosters(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/images/query?keyType=poster");
            var result = await response.Content.ReadAsStringAsync();
            var posters = JsonConvert.DeserializeObject<TVDBArtworkResponse>(result).Data;
            return posters.Any() ? posters : null;
        }

        /// <summary>
        /// Gets the Fanart for this Series.
        /// </summary>
        /// <param name="SeriesID">Series to get Fanart for.</param>
        /// <returns>List of Fanart</returns>
        public async Task<IReadOnlyList<TVDBArtwork>> GetSeriesFanart(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/images/query?keyType=fanart");
            var result = await response.Content.ReadAsStringAsync();
            var fanart = JsonConvert.DeserializeObject<TVDBArtworkResponse>(result).Data;
            return fanart.Any() ? fanart : null;
        }

        /// <summary>
        /// Gets a Series only with specified properties.
        /// </summary>
        /// <param name="SeriesID">Series ID to fetch.</param>
        /// <returns></returns>
        public SeriesFilterRequest GetFilteredSeries(uint SeriesID)
        {
            return new SeriesFilterRequest(ApiConfiguration, SeriesID);
        }
    }
}