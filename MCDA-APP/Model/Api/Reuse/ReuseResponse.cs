using Newtonsoft.Json;

namespace MCDA_APP.Model.Api.Reuse
{
    public class ReuseResponse
    {
        [JsonProperty("data")]
        public Data? Data { get; set; }

        [JsonProperty("isMaintenance")]
        public bool IsMaintenance { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
