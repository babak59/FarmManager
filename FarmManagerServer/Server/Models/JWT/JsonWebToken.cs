using Newtonsoft.Json;

namespace Server.Models.JWT
{
    public class JsonWebToken
    {
        #region Properties

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("expires")]
        public long Expires { get; set; }

        #endregion
    }
}
