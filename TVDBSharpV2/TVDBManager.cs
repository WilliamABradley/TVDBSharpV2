using System;
using TVDBSharp.Services;

namespace TVDBSharp
{
    public class TVDBManager
    {
        private TVDBConfiguration apiConfiguration;
        public const string DefaultUrl = "https://api.thetvdb.com";
        public const string TVDBBannersUrl = "http://thetvdb.com/banners/";
        public readonly AuthenticationService Authentication;
        public readonly SeriesService Series;
        public readonly EpisodesService Episodes;
        public readonly UpdateService Updates;
        public readonly ActorService Actors;

        /// <summary>
        /// Creates a new instance with the provided api configuration
        /// </summary>
        /// <param name="apiConfiguration">The API configuration</param>
        private TVDBManager(TVDBConfiguration apiConfiguration)
        {
            if (apiConfiguration == null)
                throw new ArgumentNullException(nameof(apiConfiguration));

            // Init Services
            Authentication = new AuthenticationService(apiConfiguration);
            Series = new SeriesService(apiConfiguration);
            Episodes = new EpisodesService(apiConfiguration);
            Updates = new UpdateService(apiConfiguration);
            Actors = new ActorService(apiConfiguration);
            this.apiConfiguration = apiConfiguration;
        }

        /// <summary>
        /// Creates a new instance with the provided API key and a base api url
        /// </summary>
        /// <param name="Token">The Authenticated Token provided by TVDB, by entering API key, Login Details into Login Function</param>
        /// <param name="baseUrl">The API base url</param>
        public TVDBManager(string Token, string BaseUrl = DefaultUrl) : this(new TVDBConfiguration(Token, BaseUrl))
        {
        }

        /// <summary>
        /// Creates a new instance with the  base api url, can only be used to Auth
        /// </summary>
        /// <param name="BaseUrl"></param>
        public TVDBManager(string BaseUrl = DefaultUrl) : this(new TVDBConfiguration(null, BaseUrl))
        {
        }

        public void Authenticate(string Token)
        {
            apiConfiguration.SetToken(Token);
        }
    }
}