using Newtonsoft.Json;
using System.Threading.Tasks;
using TVDBSharp.Models;
using TVDBSharp.Models.Requests;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    /// <summary>
    /// Methods relating to Authentication of the Client.
    /// </summary>
    public class AuthenticationService : ServiceBase
    {
        internal AuthenticationService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        /// <summary>
        /// Gets the JWT Token from TVDB using the provided Credentials.
        /// </summary>
        /// <param name="Credentials">Credential Information</param>
        /// <returns>TVDB Token information</returns>
        public async Task<TVDBJwtToken> GetJwtToken(CredentialPacket Credentials)
        {
            var reponse = await PostAsync(ApiConfiguration.BaseUrl + "/login", JsonConvert.SerializeObject(Credentials));
            var result = await reponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBTokenResponse>(result).Data;
        }

        /// <summary>
        /// Requests a refresh of the JWT Token.
        /// </summary>
        /// <returns>New TVDB Token information</returns>
        public async Task<TVDBJwtToken> RefreshToken()
        {
            var reponse = await GetAsync(ApiConfiguration.BaseUrl + "/refresh_token");
            var result = await reponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBTokenResponse>(result).Data;
        }
    }
}