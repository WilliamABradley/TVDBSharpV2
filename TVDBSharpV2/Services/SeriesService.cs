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
        /// <returns>List of Series results or null if none where found</returns>
        public async Task<IReadOnlyCollection<TVDBSeriesQuery>> FindSeries(string query)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/search/series?name={query}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBSeriesSearchResponse>(result).Data;
        }

        /// <summary>
        /// Finds the series with matching IMDB ID.
        /// </summary>
        /// <param name="imdbId">Series IMDB ID</param>
        /// <returns>The series with matching IMDB ID or null</returns>
        public async Task<TVDBSeriesQuery> FindSeriesByImdbId(string imdbId)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/search/series?imdbId={imdbId}");
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TVDBSeriesSearchResponse>(jsonData).Data;
            return result?.First();
        }

        /// <summary>
        /// Finds the series with matching Zap2it ID.
        /// </summary>
        /// <param name="zap2itId">Series Zap2it ID</param>
        /// <returns>The series with matching Zap2it ID or null</returns>
        public async Task<TVDBSeriesQuery> FindSeriesByZap2ItId(string zap2itId)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/search/series?zap2itId={zap2itId}");
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TVDBSeriesSearchResponse>(jsonData).Data;
            return result?.First();
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

                var poster = posters.OrderByDescending(item => item.RatingsInfo.Average)
                    .ThenByDescending(item => item.RatingsInfo.Count)
                    .FirstOrDefault();

                var fanart = fanarts.OrderByDescending(item => item.RatingsInfo.Average)
                    .ThenByDescending(item => item.RatingsInfo.Count)
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