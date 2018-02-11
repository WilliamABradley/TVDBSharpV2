using Newtonsoft.Json;
using System;

namespace TVDBSharp.Models.Responses
{
    internal class TVDBTokenResponse
    {
        public TVDBJwtToken Data => new TVDBJwtToken
        {
            Token = Token,
            Expires = Expires
        };

        [JsonIgnore]
        private string _token;

        public string Token { get { return _token; } set { _token = value; Expires = DateTime.Now.AddHours(24); } }
        public DateTime Expires { get; private set; }
    }
}