namespace TVDBSharp
{
    /// <summary>
    /// The Configuration information for the API.
    /// </summary>
    internal class TVDBConfiguration
    {
        /// <summary>
        /// The JWT Token for this Configuration.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The Base Url for the API.
        /// </summary>
        public string BaseUrl { get; }

        /// <summary>
        /// Sets the JWT Token for this Client.
        /// </summary>
        /// <param name="Token">JWT Token</param>
        public void SetToken(string Token)
        {
            this.Token = $"Bearer {Token}";
        }

        /// <summary>
        /// The Constructor for <see cref="TVDBConfiguration"/>.
        /// </summary>
        /// <param name="Token">JWT Token</param>
        /// <param name="BaseUrl">The Base Url for the API</param>
        public TVDBConfiguration(string Token, string BaseUrl)
        {
            if (!string.IsNullOrWhiteSpace(Token)) SetToken(Token);
            this.BaseUrl = BaseUrl;
        }
    }
}