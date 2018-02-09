namespace TVDBSharp.Models.Requests
{
    public class CredentialPacket
    {
        public CredentialPacket(string Apikey, string Username = null, string Userkey = null)
        {
            this.Apikey = Apikey;
            this.Username = Username;
            this.Userkey = Userkey;
        }

        public string Apikey { get; }
        public string Username { get; }
        public string Userkey { get; }
    }
}