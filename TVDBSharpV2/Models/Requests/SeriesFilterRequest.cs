using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using TVDBSharp.Models.Responses;
using TVDBSharp.Services;

namespace TVDBSharp.Models.Requests
{
    /// <summary>
    /// Fetches TVDBSeries, filtered to only show specific properties, using includeProperty() method. If not awaited, task can be created by accessing Task Property.
    /// </summary>
    public class SeriesFilterRequest : ServiceBase
    {
        internal SeriesFilterRequest(TVDBConfiguration apiConfiguration, uint SeriesID) : base(apiConfiguration)
        {
            this.SeriesID = SeriesID;
        }

        /// <summary>
        /// Gets the Awaiter from the internal Task.
        /// </summary>
        public System.Runtime.CompilerServices.TaskAwaiter<TVDBSeries> GetAwaiter()
        {
            return Task.GetAwaiter();
        }

        /// <summary>
        /// Needs to be called before beginning await or task, sets properties to be available.
        /// </summary>
        /// <param name="property">Property of Series Object</param
        public SeriesFilterRequest IncludeProperty(Expression<Func<TVDBSeries, object>> property)
        {
            Type type = typeof(SeriesFilterRequest);

            var member = property.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    property.ToString()));

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    property.ToString()));

            IncludedProperties.Add(propInfo.Name);
            return this;
        }

        /// <summary>
        /// The actual task.
        /// </summary>
        private async Task<TVDBSeries> GetFilterSeries()
        {
            string query = "/filter?keys=";
            foreach (var property in IncludedProperties)
            {
                query += property;
                if (property != IncludedProperties.Last()) query += ",";
            }
            var request = ApiConfiguration.BaseUrl + $"/series/{SeriesID}";
            if (IncludedProperties.Any()) request += query;
            var response = await GetAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var series = JsonConvert.DeserializeObject<TVDBSeriesResponse>(result).Data;
            series.ID = SeriesID;
            return series;
        }

        /// <summary>
        /// The SeriesID of this Request.
        /// </summary>
        public uint SeriesID { get; }

        /// <summary>
        /// Gets the internal Task, accessing or fetching the property will begin the API call, meaning that you should do this once all properties are included.
        /// </summary>
        public Task<TVDBSeries> Task { get { if (_Task == null) { _Task = GetFilterSeries(); } return _Task; } }

        private Task<TVDBSeries> _Task;
        private List<string> IncludedProperties = new List<string>();
    }
}