using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVDBSharp.Models;
using TVDBSharp.Models.Requests;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    public class SeriesService : ScraperBase
    {
        public SeriesService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        public async Task<IReadOnlyCollection<TVDBSeriesQuery>> FindSeries(string query)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/search/series?name={query}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBSeriesSearchResponse>(result).Data;
        }

        public async Task<TVDBSeries> GetSeries(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}");
            var result = await response.Content.ReadAsStringAsync();
            var series = JsonConvert.DeserializeObject<TVDBSeriesResponse>(result).Data;

            var poster = await GetSeriesPoster(SeriesID);
            var fanart = await GetSeriesFanart(SeriesID);
            series.Poster = poster.FileName;
            series.Fanart = fanart.FileName;

            return series;
        }

        public async Task<TVDBArtwork> GetSeriesPoster(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/images/query?keyType=poster");
            var result = await response.Content.ReadAsStringAsync();
            var posters = JsonConvert.DeserializeObject<TVDBArtworkResponse>(result).Data;
            return posters.Any() ? posters.First() : null;
        }

        public async Task<TVDBArtwork> GetSeriesFanart(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/images/query?keyType=fanart");
            var result = await response.Content.ReadAsStringAsync();
            var fanart = JsonConvert.DeserializeObject<TVDBArtworkResponse>(result).Data;
            return fanart.Any() ? fanart.First() : null;
        }

        public async Task<TVDBEpisodesQuery> QueryEpisodes(uint SeriesID)
        {
            var response = await GetAsync(ApiConfiguration.BaseUrl + $"/series/{SeriesID}/episodes/summary");
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<TVDBEpisodesQueryResponse>(result).Data;
            return data;
        }

        public SeriesFilterRequest GetFilteredSeries(uint SeriesID)
        {
            return new SeriesFilterRequest(ApiConfiguration, SeriesID);
        }
    }
}