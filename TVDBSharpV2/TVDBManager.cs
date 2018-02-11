using System;
using TVDBSharp.Services;

namespace TVDBSharp
{
    /// <summary>
    /// The TVDB V2 API Client.
    /// </summary>
    public class TVDBManager
    {
        /// <summary>
        /// The Configuration information for the API.
        /// </summary>
        private TVDBConfiguration apiConfiguration;

        /// <summary>
        /// The Primary Url for the TVDB API.
        /// </summary>
        public const string DefaultUrl = "https://api.thetvdb.com";

        /// <summary>
        /// The Primary Url for TVDB Images.
        /// </summary>
        public const string TVDBBannersUrl = "http://thetvdb.com/banners/";

        /// <summary>
        /// Methods relating to Authentication of the Client.
        /// </summary>
        public readonly AuthenticationService Authentication;

        /// <summary>
        /// Methods relating to fetching Series Information.
        /// </summary>
        public readonly SeriesService Series;

        /// <summary>
        /// Methods relating to fetching Episode information for a Series.
        /// </summary>
        public readonly EpisodesService Episodes;

        /// <summary>
        /// Methods relating to Updates to information from TVDB.
        /// </summary>
        public readonly UpdateService Updates;

        /// <summary>
        /// Methods relating to Actor Information.
        /// </summary>
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

        /// <summary>
        /// Authenticates the TVDB Client with a JWT Token if one is already created.
        /// </summary>
        /// <param name="Token">JWT Token</param>
        public void Authenticate(string Token)
        {
            apiConfiguration.SetToken(Token);
        }
    }
}