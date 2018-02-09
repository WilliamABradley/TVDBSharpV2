using Newtonsoft.Json;
using System.Threading.Tasks;
using TVDBSharp.Models.Requests;
using TVDBSharp.Models.Responses;

namespace TVDBSharp.Services
{
    public class AuthenticationService : ScraperBase
    {
        public AuthenticationService(TVDBConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        public async Task<TVDBTokenResponse> GetJwtToken(CredentialPacket Credentials)
        {
            var reponse = await PostAsync(ApiConfiguration.BaseUrl + "/login", JsonConvert.SerializeObject(Credentials));
            var result = await reponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBTokenResponse>(result);
        }

        public async Task<TVDBTokenResponse> RefreshToken()
        {
            var reponse = await GetAsync(ApiConfiguration.BaseUrl + "/refresh_token");
            var result = await reponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TVDBTokenResponse>(result);
        }
    }
}