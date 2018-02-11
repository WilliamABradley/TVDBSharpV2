using System;
using System.Net.Http;
using System.Threading.Tasks;
using TVDBSharp.Models.Exceptions;

namespace TVDBSharp.Services
{
    /// <summary>
    /// Internal Http client for calls to the TVDB API.
    /// </summary>
    public abstract class ServiceBase
    {
        internal TVDBConfiguration ApiConfiguration { get; }

        internal ServiceBase(TVDBConfiguration apiConfiguration)
        {
            this.ApiConfiguration = apiConfiguration ?? throw new ArgumentNullException(nameof(apiConfiguration));
        }

        /// <summary>
        /// Creates Authentication Headers for the Client.
        /// </summary>
        private void CreateHeaders(HttpClient client, bool requiresAuth)
        {
            if (requiresAuth) client.DefaultRequestHeaders.Add("Authorization", ApiConfiguration.Token);
        }

        protected async Task<HttpResponseMessage> GetAsync(string url, bool requiresAuth = true)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));

            try
            {
                var uri = new Uri(url);

                using (var client = new HttpClient())
                {
                    CreateHeaders(client, requiresAuth);
                    var response = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
                    if (!response.IsSuccessStatusCode && response.StatusCode != System.Net.HttpStatusCode.NotFound) throw new Exception(response.StatusCode.ToString());
                    return response;
                }
            }
            catch (Exception e)
            {
                throw new TVDBNotAvailableException(inner: e);
            }
        }

        protected async Task<HttpResponseMessage> PostAsync(string url, string data)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));

            try
            {
                var uri = new Uri(url);

                using (var client = new HttpClient())
                {
                    //CreateHeaders(client);
                    var response = await client.PostAsync(uri, new StringContent(data, new System.Text.UTF8Encoding(), "application/json"));
                    if (!response.IsSuccessStatusCode) throw new Exception(response.StatusCode.ToString());

                    return response;
                }
            }
            catch (Exception e)
            {
                throw new TVDBNotAvailableException(inner: e);
            }
        }
    }
}