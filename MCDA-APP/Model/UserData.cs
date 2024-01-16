using Newtonsoft.Json;

namespace MCDA_APP.Model
{
    internal class UserData
    {
        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}
