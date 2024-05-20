using Newtonsoft.Json;

namespace MCDA_APP.Model.Agent
{
    public class AgentStatus
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("payload")]
        public Payload? Payload { get; set; }
    }
}
