namespace TVDBSharp
{
    public class TVDBConfiguration
    {
        public string Token { get; set; }
        public string BaseUrl { get; }

        public void SetToken(string Token)
        {
            this.Token = $"Bearer {Token}";
        }

        public TVDBConfiguration(string Token, string BaseUrl)
        {
            if (!string.IsNullOrWhiteSpace(Token)) SetToken(Token);
            this.BaseUrl = BaseUrl;
        }
    }
}