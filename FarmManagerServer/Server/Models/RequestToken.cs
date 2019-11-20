using Newtonsoft.Json;

namespace Server.Models
{
    public class RequestToken
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("grant_type")]
        public string GrantType { get; set; }
    }
}
