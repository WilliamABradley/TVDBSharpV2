namespace TVDBSharp.Models.Requests
{
    /// <summary>
    /// Credential Information for requesting Authentication of the TVDB API with a possible User context.
    /// </summary>
    public class CredentialPacket
    {
        /// <summary>
        /// Constructor for <see cref="CredentialPacket"/>.
        /// </summary>
        /// <param name="Apikey">TVDB API key for the App.</param>
        /// <param name="Username">Username of TVDB User to Authenticate (Optional)</param>
        /// <param name="Userkey">User Key of TVDB User to Authenticate (Optional)</param>
        public CredentialPacket(string Apikey, string Username = null, string Userkey = null)
        {
            this.Apikey = Apikey;
            this.Username = Username;
            this.Userkey = Userkey;
        }

        /// <summary>
        /// TVDB API key for the App.
        /// </summary>
        public string Apikey { get; }

        /// <summary>
        /// Username of TVDB User to Authenticate (Optional)
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// User Key of TVDB User to Authenticate (Optional)
        /// </summary>
        public string Userkey { get; }
    }
}