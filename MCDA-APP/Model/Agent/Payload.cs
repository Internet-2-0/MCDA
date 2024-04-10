using Newtonsoft.Json;

namespace MCDA_APP.Model.Agent
{
    public class Payload
    {
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}