using Newtonsoft.Json;

namespace MCDA_APP.Model.Agent
{
    public class Payload
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("response")]
        public string? Response { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}